using Dapper;

using MandiPOS.CLasses;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using static MandiPOS.SQL;
namespace MandiPOS.GUI
{
    public partial class frmChithaJaatReport : Form
    {
        clsResize objresizer;
        public frmChithaJaatReport()
        {
            InitializeComponent();
            panel1.VisibleChanged += Panel1_VisibleChanged;
            objresizer = new clsResize(this);
            this.Load += FrmChithaJaatReport_Load;
            this.Resize += FrmChithaJaatReport_Resize;
            cmbGroups.DropDownDataSource = MasterAccountsService.GetMasterAccounts();
            cmbCity.DropDownDataSource = SQL.GetCities();
            //bs.DataSource = MasterAccountsService.GetMasterAccounts();
            cmbGroups.Text = "گروپ منتخب کریں";
            cmbCity.Text = "شہر منتخب کریں";
            cmbChithaType.RegisterFocus(true);
            dtp.RegisterFocus(false);
            dtp.EnterToNext();
            cmbChithaType.EnterToNext();
            cmbChithaType.SelectedIndex = 0;
            cmbChithaType.Select();
        }

        private void Panel1_VisibleChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                btnShowHIde.Caption = "Hide Panel";
            }
            else
            {
                btnShowHIde.Caption = "Show Panel";
            }
        }

        private void FrmChithaJaatReport_Resize(object sender, EventArgs e)
        {
            objresizer._resize();
        }

        private void FrmChithaJaatReport_Load(object sender, EventArgs e)
        {
            objresizer._get_initial_size();
            WindowState = FormWindowState.Maximized;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (cmbChithaType.SelectedIndex == -1)
            {
                this.Error("رپورٹ کی قسم منتخب کریں");
                return;
            }

            string cities = string.Join(",",
    cmbCity?.CheckedItems?
        .Cast<tblCity>()
        .Where(acc => acc != null && acc.ID != null)
        .Select(acc => acc.ID.ToString()) ?? Enumerable.Empty<string>());
            string groups = string.Join(",",
    cmbGroups?.CheckedItems?
        .Cast<MasterAccounts>()
        .Where(acc => acc != null && acc.ID != null)
        .Select(acc => acc.ID.ToString()) ?? Enumerable.Empty<string>());
            if (cmbChithaType.SelectedValue.toInt() == 1)
            {
                string sql = $@"WITH EndBalances AS
    (
        SELECT AccountID, SUM(DebitAmount - CreditAmount) AS 'EndBalance'
        FROM vwTrx 
        WHERE VoucherDate <= '{dtp.Value.Date:yyyy-MM-dd}'
        GROUP BY AccountID
    )
    SELECT acc.AccountCode as ID,
        acc.AccountTitle,
mas.AccountTitle as 'MasterAccount',
        acc.RefName,
        acc.Contact,
        city.CityName,
        eb.EndBalance 
    FROM EndBalances eb 
    LEFT JOIN DetailAccounts acc ON eb.AccountID = acc.ID 
    left Join MasterAccounts mas ON acc.MasterID = mas.ID
    LEFT JOIN tblCity city ON acc.CityID = city.ID
    WHERE 1=1 {(string.IsNullOrEmpty(groups) ? "" : $" and acc.MasterID in ({groups})")} {(string.IsNullOrEmpty(cities) ? "" : $" and city.ID in ({cities})")}
Order By mas.id";
                DataTable dt = new DataTable();
                using (var db = new db())
                {
                    var reader = db.ExecuteReader(sql);
                    dt.Load(reader);
                }
                if (dt.Rows.Count > 0)
                {
                    var report = new rptChithaFull(dt, dtp.Value.ToString("dd/MM/yyyy"));
                    report.CreateDocument();
                    documentViewer1.DocumentSource = report;
                    panel1.Visible = false;
                }
                else
                {
                    documentViewer1.Document = null;
                }
            }


        }

        private void btnShowHIde_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
    }
}
