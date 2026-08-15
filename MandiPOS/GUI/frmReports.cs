
using Dapper;
using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using MandiPOS.Reports;
using MandiPOS.Reports.ReportClasses;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmReports : Form
    {
        clsResize obj;
        int CurrentPartyID = 0;
        public frmReports(int v)
        {
            InitializeComponent();
            dtp1.KeyDown += Dtp1_KeyDown;
            dtp2.KeyDown += (s, e) =>
            {
                if (e.EnterKey())
                {
                    txtPartyTitle.Select();
                }
            };
            txtPartyTitle.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down)
                {
                    dgvHelp.Focus();
                }
                if (e.EnterKey())
                {
                    uiButton1.Select();
                }
                if (e.EscapeKey())
                {
                    dgvHelp.Visible = false;
                }
            };
            dgvHelp.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    dgvHelp.Visible = false;
                    txtPartyTitle.Focus();
                }
                if (e.EnterKey())
                {
                    if (dgvHelp.IsRow())
                    {
                        txtPartyTitle.Text = dgvHelp.CurrentRow.Cells["AccountTitle"].Value.ToString();
                        CurrentPartyID = dgvHelp.CurrentRow.Cells["ID"].Value.toInt();
                        dgvHelp.Visible = false;
                        txtPartyTitle.Focus();
                    }
                }
            };
            txtPartyTitle.RegisterFocus(true);
            txtPartyTitle.TextChanged += TxtPartyTitle_TextChanged;
            obj = new clsResize(this);
            this.Load += FrmReports_Load;
            this.Resize += FrmReports_Resize;
            SetActiveReport(v);
        }

        private void Dtp1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                dtp2.Select();
            }
        }

        private void TxtPartyTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (txtPartyTitle.Focused && txtPartyTitle.Text.Length > 0)
            {
                dgvHelp.Visible = true;
                bsParties.Filter = $"AccountTitle like '%{txtPartyTitle.Text}%'";
                bsParties.ResetBindings(false);
            }
            else
            {
                bsParties.RemoveFilter();
            }
            CurrentPartyID = 0;
        }

        private void SetActiveReport(int v)
        {
            switch (v)
            {
                case 0: report01.Checked = true; break;
            }
        }

        private void FrmReports_Resize(object sender, System.EventArgs e)
        {
            obj._resize();
        }

        DataTable dtParties = new DataTable();
        private void FrmReports_Load(object sender, System.EventArgs e)
        {
            obj._get_initial_size();
            dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
            bsParties.DataSource = dtParties;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            if (panel1.Visible)
            {
                barButtonItem1.Caption = "Hide Panel";
            }
            else
            {
                barButtonItem1.Caption = "Show Panel";
            }

        }

        private void report01_CheckedChanged(object sender, System.EventArgs e)
        {
            SetReportSettings();
        }

        int ReportID = 0;
        private void SetReportSettings()
        {
            if (report01.Checked)
            {
                ReportID = 0;
            }
            // if (report02.Checked)
            //{
            // ReportID = 1;
            //}
            SetReportControls(ReportID);
            dtp1.Select();
        }

        private void SetReportControls(int reportID)
        {

            foreach (Control c in panel2.Controls)
            {
                if (reportID == 0 && c.Name == dgvLedger.Name.ToString())
                {
                    c.Visible = true;
                    c.Dock = DockStyle.Fill;
                }
                else
                {
                    c.Visible = false;
                }
            }
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            if (dtp1.Value.Date > dtp2.Value.Date)
            {
                this.Error("Start date cannot be greater than end date.");
                return;
            }
            if (ReportID == 0)
            {
                ShowLedger();
            }
            if (ReportID == 1)
            {
                ShowChitha();
            }
        }

        private void ShowChitha()
        {

        }

        private void ShowLedger()
        {
            if (CurrentPartyID == 0)
            {
                this.Error("Please select a party to show ledger.");
                return;
            }

            var acc = DetailAccounts.GetAccountByID(CurrentPartyID);
            if (acc == null)
            {
                General.Error(null, "Account not found.");
                clsLedgerBindingSource.DataSource = null;
                clsLedgerBindingSource.ResetBindings(false);
                return;
            }
            var result = new db().Query<clsLedger>("sp_Ledger", new { AccountID = CurrentPartyID, StartDate = dtp1.Value.Date, EndDate = dtp2.Value.Date },
         commandType: CommandType.StoredProcedure).ToList<clsLedger>();
            clsLedgerBindingSource.DataSource = result;
            clsLedgerBindingSource.ResetBindings(false);
        }

        private void dgvLedger_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (dgvLedger.IsRow() && !string.IsNullOrEmpty(dgvLedger.CurrentRow.Cells["BillNo"].Value.ToString()))
            {
                if (dgvLedger.CurrentRow.Cells["BillNo"].Value.ToString() == "0")
                {
                    this.Info("This is Voucher.");
                    return; // No bill number to show
                }
                string billNo = dgvLedger.CurrentRow.Cells["BillNo"].Value.ToString();
                using (var rpt = new saleBill(billNo, 1))
                {
                    rpt.CreateDocument();
                    using(XtraForm1 frm = new XtraForm1(rpt) { StartPosition = FormStartPosition.CenterScreen })
                    {
                        
                        frm.WindowState = FormWindowState.Normal;
                        frm.KeyPreview = true;
                        frm.KeyDown += (s, ev) =>
                        {
                            if (ev.EscapeKey())
                            {
                                frm.Close();
                            }
                        };
                        frm.ShowDialog(this);
                    }
                }
            }
        }

        private void uiButton2_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmChithaJaatReport() { StartPosition = FormStartPosition.CenterScreen })
            {
                frm.ShowDialog(this);
            }
        }
    }
}
