using Dapper;

using DevExpress.XtraReports.UI;

using Janus.Windows.GridEX;

using MandiPOS.CLasses;
using MandiPOS.Reports;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using static MandiPOS.SQL;

namespace MandiPOS.GUI
{
    public partial class frmKhasraSummary : Form
    {
        clsResize objresizer;
        DataTable dtRecords = new DataTable();
        DateTime _date = DateTime.Now;
        public frmKhasraSummary(DateTime date)
        {
            InitializeComponent();
            _date = date;
            dgv.setFormat();
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            objresizer = new clsResize(this);
            this.Load += FrmKhasraSummary_Load;
            this.Resize += FrmKhasraSummary_Resize;
            dtRecords = new db().Query<vw_KhasraSummary>($"exec sp_GetKhasraSummary '{date:yyyy-MM-dd}';").ToDataTable();
            decimal naqad = dtRecords.Compute("Sum(TotalAmount)", "AccountTitle LIKE '%نقد سیل%'").toDecimal();
            decimal udhar = dtRecords.Compute("Sum(TotalAmount)", "AccountTitle Not LIKE '%نقد سیل%'").toDecimal();
            _naqad.Text = naqad.ToString("0.##");
            _udhar.Text = udhar.ToString("0.##");
            lbldate.Text = date.ToString("dd-MMM-yyyy");
            bs.DataSource = dtRecords;
        }

        private void Dgv_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            if (dgv.IsRow())
            {
                bool state = dgv.CurrentRow.Cells["select"].Value.toBool();
                dgv.CurrentRow.Cells["select"].Value = !state;
            }
        }

        private void FrmKhasraSummary_Resize(object sender, EventArgs e)
        {
            objresizer._resize();
        }

        private void FrmKhasraSummary_Load(object sender, EventArgs e)
        {
            objresizer._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var rows = dgv.GetCheckedRows();
            List<string> lst = new List<string>();
            if (rows.Length > 0)
            {
                using (new waitForm())
                {
                    foreach (GridEXRow row in rows)
                    {
                        string s = dtRecords.Rows[row.RowIndex]["PartyID"].ToString();
                        lst.Add(s);
                    }
                    if (lst.Count > 0)
                    {
                        CollectBills(lst);
                    }
                }
            }
            else
            {
                this.Error("کوئی ریکارڈ منتخب نہیں ہے۔");
                return;
            }

        }

        private void CollectBills(List<string> lst)
        {
            XtraReport mainReport = null;
            foreach (string s in lst)
            {
                if (s == "1495")
                {
                    continue;
                }
                string sql = $@"SELECT 
	p.ItemTitle as 'Item',
    CustomerRate  as Rate,
    SUM(ItemQty) AS Qty,
    SUM(ItemWeight) AS 'Weight',
    SUM(CustomerAmount) AS Amount,
    SUM(LagaAmount) AS Laga
FROM (
    SELECT 
        sd.PartyID,
        sd.ItemID,
        sd.ItemQty,
        sd.ItemWeight,
        sd.CustomerRate,
        sd.CustomerAmount,
        sd.LagaAmount 
    FROM tblsale s 
    LEFT JOIN tblSaleDetail sd ON s.ID = sd.SaleID
    WHERE s.ArrivalDate = '{_date.Date:yyyy-MM-dd}' AND sd.PartyID = '{s.toInt()}'
) AS SubQuery
left join tblItems p on SubQuery.ItemID=p.ID
GROUP BY 
   p.ItemTitle,
    CustomerRate
ORDER BY 
    p.ItemTitle";
                List<clsCustomerBill> data = new db().Query<clsCustomerBill>(sql).ToList();


                var rpt = new CustomerBill(s.toInt(), _date.Date, data);
                rpt.CreateDocument();
                if (mainReport == null)
                {
                    mainReport = rpt;
                }
                else
                {
                    mainReport.Pages.AddRange(rpt.Pages);
                }
            }
            mainReport.ShowPreview();
        }
    }
}
