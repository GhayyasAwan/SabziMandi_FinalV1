using Dapper;
using DevExpress.XtraReports.UI;
using Janus.Windows.GridEX;
using MandiPOS.CLasses;
using MandiPOS.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

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
            dtRecords = new db().Query<vw_KhasraSummary>($"Select * from vw_KhasraSummary Where [Date]='{date:yyyy-MM-dd}' Order By SortOrder, Case When SortOrder=1 then TotalAmount else null End Desc").ToDataTable();
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
                var rpt = new CustomerBill(s.toInt(), _date.Date);
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
            using (XtraForm1 frm = new XtraForm1(mainReport))
            {
                frm.ShowDialog();
                mainReport?.Dispose();
            }
        }
    }
}
