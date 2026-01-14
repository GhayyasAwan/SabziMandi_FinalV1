using Dapper;

using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model.History;

using MandiPOS.CLasses;
using MandiPOS.Reports;
using MandiPOS.Reports.ReportClasses;

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmReportsNew : Form
    {
        int ReportID = 1;
        private DataTable dtCustomers;
        clsResize objresizer;
        int externalid = 0;
        public frmReportsNew(int reportID)
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
            dtp.Value = dtp2.Value = DateTime.Now.Date;
            pnlMain.Resize += FlowLayoutPanel1_Resize;
            _pname.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down)
                {
                    dgvHelp.Focus();
                }
                if (e.EnterKey() && _pname.Text.Trim().Length > 0)
                {
                    btnViewReport.Select();
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
                    _pname.Focus();
                }
                if (e.EnterKey())
                {
                    if (dgvHelp.IsRow())
                    {
                        triggerSetReport = false;
                        _pname.Text = dgvHelp.CurrentRow.Cells["AccountTitle"].Value.ToString();
                        _pid.Text = dgvHelp.CurrentRow.Cells["ID"].Value.ToString();
                        dgvHelp.Visible = false;
                        _pname.Focus();
                        triggerSetReport = true;
                    }
                }
            };
            externalid = reportID;
            objresizer = new clsResize(this);
            SetRadioButtonAppearance();
            txtBillNo.RegisterFocus(false);
            this.Load += FrmReportsNew_Load;
            this.Resize += FrmReportsNew_Resize;
            txtBillNo.EnterToNext();
            btnViewReport.RegisterFocus(false);
            cmbGroups.RegisterFocus(true);
            cmbGroups.EnterToNext();
            _pname.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.Back)
                {
                    _pname.Clear();
                }
            };


        }
        bool triggerSetReport = true;
        private void FlowLayoutPanel1_Resize(object sender, EventArgs e)
        {

        }

        void SetRadioButtonAppearance()
        {
            foreach (Control control in pnlMain.Controls)
            {
                if (control is RadioButton radio)
                {
                    radio.Appearance = Appearance.Button;
                    radio.FlatStyle = FlatStyle.Flat;
                    radio.FlatAppearance.BorderSize = 0;
                    radio.FlatAppearance.MouseOverBackColor = SystemColors.Highlight;

                    // Initial setup
                    UpdateRadioButtonAppearance(radio);

                    // Handle checked changed event
                    radio.CheckedChanged += (sender, e) =>
                    {
                        UpdateRadioButtonAppearance((RadioButton)sender);
                    };
                }
            }
        }
        private void UpdateRadioButtonAppearance(RadioButton radio)
        {
            if (radio.Checked)
            {
                radio.BackColor = Color.PaleGreen;
                radio.ForeColor = Color.Black;
                radio.FlatAppearance.BorderSize = 1;
            }
            else
            {
                radio.BackColor = SystemColors.Control;
                radio.ForeColor = Color.Black;
                radio.FlatAppearance.BorderSize = 0;
            }
        }
        private void FrmReportsNew_Resize(object sender, System.EventArgs e)
        {
            //  objresizer._resize();

        }
        DataTable dtSubParties = new DataTable();
        bool isLoading = true;
        private void FrmReportsNew_Load(object sender, System.EventArgs e)
        {
            StringBuilder b = new StringBuilder();
            foreach (Control c in uiGroupBox1.Controls)
            {
                if (c is RadioButton rb)
                {
                    //                   b.AppendLine($@"MERGE [dbo].[tblPermissions] AS target
                    //USING (SELECT N'{rb.Text}' AS PermissionTitle) AS source
                    //ON target.PermissionTitle = source.PermissionTitle
                    //WHEN MATCHED THEN
                    //    UPDATE SET PermissionTitle = source.PermissionTitle
                    //WHEN NOT MATCHED THEN
                    //    INSERT (PermissionTitle, IsReport)
                    //    VALUES (source.PermissionTitle, 1);");
                    switch (rb.Name)
                    {
                        case "rb_Report15":
                            rb.Enabled = rb.Visible = true; break;
                        case "rb_Report06":
                            rb.Enabled = rb.Visible = true; break;
                        default: rb.Enabled = rb.Visible = General.IsAdmin; break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(b.ToString()))
            {
                using (var db = new db())
                {
                    using (var trx = db.BeginTransaction())
                    {
                        try
                        {
                            db.Execute(b.ToString(), transaction: trx);
                            trx.Commit();
                        }
                        catch
                        {
                            trx.Rollback();
                        }
                    }
                }
            }
            if (isLoading)
            {
                SetExternalReport();
                isLoading = false;
            }

            objresizer._get_initial_size();
            cmbGroups.DropDownDataSource = MasterAccountsService.GetMasterAccounts(" where ID<>10");
            cmbCity.DropDownDataSource = SQL.GetCities();
            cmbCity.RegisterFocus(true);
            cmbCity.EnterToNext();
            dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
            dtSubParties = DetailAccountService.GetAccountsViewList().ToDataTable();
            bsParties.DataSource = dtParties;
            dtp.RegisterFocus(false); dtp.EnterToNext();
            dtp2.RegisterFocus(false); dtp2.EnterToNext();
            _pname.RegisterFocus(true);
            // this.WindowState = FormWindowState.Maximized;

        }

        private void SetExternalReport()
        {
            switch (externalid)
            {
                case 1:
                    rb_Report01.PerformClick();
                    break;
                case 2:
                    rb_Report02.PerformClick();
                    break;
                case 6:
                    rb_Report06.PerformClick();
                    break;
                case 10:
                    rb_Report10.PerformClick();
                    break;
                case 13: rb_Report13.PerformClick(); break;
                case 15: rb_Report15.PerformClick(); break;
                default:
                    rb_Report01.PerformClick();
                    break;
            }
        }

        private void SetReport(object sender, System.EventArgs e)
        {

            if (!triggerSetReport) { return; }
            dtp.MinDate = dtp2.MinDate = General.MinimumDate.AddDays(-5);
            dtp.Value = dtp2.Value = DateTime.Now;
            lblTitle.Text = ((RadioButton)sender).Text.ToString();
            string reportName = ((RadioButton)sender).Name.ToString();
            // ((RadioButton)sender).Checked = true;
            switch (reportName)
            {
                case "rb_Report01": //لین دین
                    ReportID = 1;
                    bsParties.DataSource = dtParties;
                    dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
                    bsParties.DataSource = dtParties;
                    dtp.Show();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Show(); lblParty.Show();
                    txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rbBqayaSale": //بقایا سیل
                    ReportID = 22;
                    bsParties.DataSource = dtParties;
                    dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
                    bsParties.DataSource = dtParties;
                    dtp.Show();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Show(); lblParty.Show();
                    txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report02": //Cash Rokar
                    ReportID = 2;
                    bsParties.DataSource = dtParties;
                    dtp2.Hide(); lblDate2.Hide();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    _pname.Hide(); lblParty.Hide(); _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report03": //Chitha Complete
                    ReportID = 3;
                    bsParties.DataSource = dtParties;
                    cmbSort.SelectedValue = 0;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide(); _pname.Clear();
                    lblgroup.Show(); cmbGroups.Show(); cmbGroups.CheckedItems = null;
                    cmbCity.Show(); lblCity.Show(); cmbCity.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report04": //Chitha Group Wise
                    ReportID = 4;
                    bsParties.DataSource = dtParties;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbSort.SelectedValue = 0;
                    cmbCity.Hide(); lblCity.Hide();
                    cmbCity.CheckedItems = null;
                    lblgroup.Show(); cmbGroups.Show(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report05": //Chitha City Wise
                    ReportID = 5; bsParties.DataSource = dtParties;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    cmbSort.SelectedValue = 0;
                    _pname.Clear();
                    cmbCity.Show(); lblCity.Show();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report06": //گاہک بل
                    ReportID = 6; bsParties.DataSource = dtParties;
                    dtCustomers = DetailAccountService.CustomerAccounts().ToDataTable();
                    bsParties.DataSource = dtCustomers;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Show(); lblParty.Show();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report07": //بیوپاری بکری
                    ReportID = 7;
                    dtParties = DetailAccountService.VendorAccounts().ToDataTable();
                    bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Show();
                    lblParty.Show();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report08": //گاہک بکری
                    ReportID = 8; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    cmbGroups.CheckedItems = null;
                    dtp.Select();
                    break;
                case "rb_Report09": //خسرہ گاہک
                    ReportID = 9; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    cmbGroups.CheckedItems = null;
                    dtp.Select();
                    break;
                case "rb_Report10": //خسرہ گاہک مختصر
                    ReportID = 10; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    cmbGroups.CheckedItems = null;
                    dtp.Select();
                    break;
                case "rb_Report11": //ماہانہ آمدن فرم
                    ReportID = 11; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    cmbGroups.CheckedItems = null;
                    dtp.Select();
                    break;
                case "rb_Report12": //ٹاپ کمیشن رپورٹ
                    ReportID = 12; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report13": //ریکوری
                    ReportID = 13; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null; txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report14": //بیوپاری بکری گاہک وار
                    ReportID = 14; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null;
                    txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report15": //بیوپاری بکری گاہک وار
                    ReportID = 15; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null;
                    txtBillNo.Visible = lblBill.Visible = true;
                    dtp.Visible = lblDtp.Visible = false;
                    txtBillNo.Select();
                    break;
                case "rb_Report16":
                    ReportID = 16;
                    dtSubParties = DetailAccountService.GetSubPartiesAccountList().ToDataTable();
                    bsParties.DataSource = dtSubParties;
                    dtp.Show();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Show(); lblParty.Show(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report17": //ادھار سیل
                    ReportID = 17; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null;
                    txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report18": //نقد سیل
                    ReportID = 18; bsParties.DataSource = dtParties;
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Hide(); lblDate2.Hide();
                    _pname.Hide(); lblParty.Hide();
                    _pname.Clear();
                    cmbCity.Hide(); lblCity.Hide();
                    lblgroup.Hide(); cmbGroups.Hide();
                    cmbGroups.CheckedItems = null;
                    txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report19": //ماسٹر شیٹ
                    ReportID = 19;
                    bsParties.DataSource = dtParties;
                    dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
                    bsParties.DataSource = dtParties;
                    dtp.Show();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Show(); lblParty.Show(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report20": //فرد حساب
                    ReportID = 20;
                    bsParties.DataSource = dtParties;
                    dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
                    bsParties.DataSource = dtParties;
                    dtp.Show();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Show(); lblParty.Show(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;
                case "rb_Report21":
                    ReportID = 21;
                    bsParties.DataSource = null;
                    dtParties = DetailAccountService.GetRefferalsList().ToDataTable();
                    bsParties.DataSource = dtParties;
                    dtp.Show();
                    lblgroup.Hide(); cmbGroups.Hide(); cmbGroups.CheckedItems = null;
                    cmbCity.Hide(); lblCity.Hide(); cmbCity.CheckedItems = null;
                    dtp2.Show(); lblDate2.Show();
                    _pname.Show(); lblParty.Show(); txtBillNo.Visible = lblBill.Visible = false;
                    dtp.Visible = lblDtp.Visible = true;
                    dtp.Select();
                    break;


            }
            cmbSort.Visible = lblSort.Visible = cmbType.Visible = cmbCity.Visible;
            cbInActive.Checked = true;
            cbInActive.Visible = cbZero.Visible = cbSummary.Visible = false;
            cbZero.Checked = !cbZero.Visible;
            cbSummary.Checked = !cbSummary.Visible;
        }

        private void UncheckAll(object sender)
        {

        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            if (ReportID == 1) //لین دین کھاتہ
            {
                ShowLedger(0); return;
            }
            if (ReportID == 22) //لین دین کھاتہ
            {
                ShowBaqayaSale(); return;
            }
            if (ReportID == 2) //کیش روکڑ
            {
                using (new waitForm())
                {
                    var report = new rptRokar(dtp.Value.Date);
                    ShowReport(report, 1.4f);
                }
                return;
            }
            if (ReportID == 3) //چٹھہ مکمل
            {
                ShowChitha(0); return;
            }
            if (ReportID == 4) //چٹھہ گروپ وار
            {
                ShowChitha(1); return;
            }
            if (ReportID == 5) //چٹھہ شہر وار
            {
                ShowChitha(2); return;
            }
            if (ReportID == 6) //گاہک بل
            {
                ShowCustomerBill(); return; //City Wise Chitha
            }
            if (ReportID == 7) //بیوپاری بکری
            {
                ShowVendorSale(); return;
            }
            if (ReportID == 8) //گاہک بکری
            {
                ShowCustomerSale(); return;
            }

            if (ReportID == 9) //گاہک خسرہ
            {
                ShowKhasra(); return;
            }
            if (ReportID == 10) //گاہک خسرہ مختصر
            {
                ShowKhasraSummary(); return;
            }
            if (ReportID == 11) //ماہانہ آمدن فرم
            {
                ShowMonthlyIncomeReport(); return;
            }
            if (ReportID == 12) //Top Commision Report
            {
                ShowTopCommissionReport(); return;
            }
            if (ReportID == 13) //Recovery
            {
                ShowRecoveryReport(); return;
            }
            if (ReportID == 14) //Customer Wise Vendor Sale
            {
                ShowCustomerWiseVendorSale(0); return;
            }
            if (ReportID == 15) //Customer Wise Vendor Sale
            {
                ShowCustomerBillPrint(); return;
            }
            if (ReportID == 16) //Customer Wise Vendor Sale
            {
                ShowSubpartyReport(); return;
            }
            if (ReportID == 17) //Credit Sale
            {
                ShowCustomerWiseVendorSale(2); return;
            }
            if (ReportID == 18) //Cash Sale
            {
                ShowCustomerWiseVendorSale(1); return;
            }
            if (ReportID == 19) //Master Sheet
            {
                ShowMaterSheet(1); return;
            }
            if (ReportID == 20) //فردحساب
            {
                ShowLedger(1); return;
            }
            if (ReportID == 21) //معرفت رپورٹ
            {
                ShowRefReport(); return;
            }
        }

        private void ShowBaqayaSale()
        {
            DateTime d1 = dtp.Value.Date;
            DateTime d2 = dtp2.Value.Date;
            int partyid = _pid.Text.Trim().toInt();
            using (new waitForm())
            {
                var data = vwBaqayaSaleService.GetBaqayaSaleList(d1, d2, partyid).ToList();
                string dateRange = $"{d1:dd-MM-yyyy}-{d2:dd-MM-yyyy}";
                var report = new rptBaqayaSale(data, dateRange, partyid);
                report.CreateDocument();
                ShowReport(report);
            }
        }

        private void ShowRefReport()
        {
            using (new waitForm())
            {
                int refrerID = _pid.Text.Trim().toInt();
                string partyName = _pname.Text.Trim();


                string sql = $@"WITH EndBalances AS
    (
        SELECT AccountID, SUM(DebitAmount - CreditAmount) AS 'EndBalance'
        FROM vwTrx 
        WHERE VoucherDate <= '{dtp.Value.Date:yyyy-MM-dd}'
            AND AccountID IN (SELECT ID FROM DetailAccounts WHERE RefrenceID='{refrerID}')
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
    WHERE 1=1 and (acc.AccountTitle Not Like N'نقد سیل') and acc.MasterID<>10
Order By mas.id";
                DataTable dt = new DataTable();
                using (var db = new db())
                {
                    var reader = db.ExecuteReader(sql);
                    dt.Load(reader);
                }
                if (dt.Rows.Count > 0)
                {
                    var report = new rptRefRalReport(dt, dtp.Value.ToString("dd/MM/yyyy"));
                    report.CreateDocument();
                    ShowReport(report);
                }
                else
                {
                    this.Info("کوئی ریکارڈ موجود نہیں ہے۔");
                }
            }
        }
        private void ShowMaterSheet(int reportType)
        {
            if (_pid.Text.toInt() > 0)
            {
                using (new waitForm())
                {
                    var report = new rptMasterSheet(_pid.Text.toInt(), dtp.Value.Date, dtp2.Value.Date);
                    report.CreateDocument();
                    ShowReport(report);
                }
            }
            else
            {
                this.Error("پارٹی منتخب کریں");
                return;
            }
        }

        DataTable dtParties = new DataTable();
        private void _pname_TextChanged(object sender, System.EventArgs e)
        {
            if (_pname.Focused && _pname.Text.Length > 0)
            {
                dgvHelp.Visible = true;

                string[] parts = _pname.Text.Trim()
    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                DataTable table = (DataTable)bsParties.DataSource;

                //// Make sure we have a helper column for sorting
                //if (!table.Columns.Contains("SearchPriority"))
                //    table.Columns.Add("SearchPriority", typeof(int));

                //// Reset priorities before setting new ones
                //foreach (DataRow row in table.Rows)
                //{
                //    row["SearchPriority"] = 1; // default (contains only)
                //}

                //if (parts.Length > 0)
                //{
                //    string part = parts[0];

                //    foreach (DataRow row in table.Rows)
                //    {
                //        string title = row["AccountTitle"].ToString();
                //        string code = row["AccountCode"].ToString();

                //        if (title.StartsWith(part, StringComparison.OrdinalIgnoreCase) ||
                //            code.StartsWith(part, StringComparison.OrdinalIgnoreCase))
                //        {
                //            row["SearchPriority"] = 0; // starts with = higher priority
                //        }
                //    }
                //}

                // Build filter condition (same as before)
                var filters = parts.Select(part =>
                    $"(AccountTitle LIKE '%{part.Replace("'", "''")}%' " +
                    $"OR Convert(AccountCode, 'System.String') LIKE '%{part.Replace("'", "''")}%')"
                );
                bsParties.Filter = string.Join(" AND ", filters);

                // Apply sorting
                DataView view = table.DefaultView;
                // view.Sort = "SearchPriority ASC";
                bsParties.ResetBindings(false);
            }

            else
            {
                bsParties.RemoveFilter();
            }
            _pid.Clear();
        }



        private void ShowSubpartyReport()
        {
            if (_pid.Text.toInt() > 0)
            {
                var frm = new frmSubPartiesSale(_pid.Text.toInt(), dtp.Value.Date, dtp2.Value.Date);
                frm.Show();
            }
            else
            {
                this.Error("پارٹی منتخب کریں");
                return;
            }

        }

        private void ShowCustomerBillPrint()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text))
            {
                this.Error("بل نمبر درج کریں");
                return;
            }
            using (new waitForm())
            {
                var report = new saleBill(txtBillNo.Text.Trim(), 1);
                report.CreateDocument();
                ShowReport(report);
            }
        }

        private void ShowCustomerWiseVendorSale(int type)
        {
            using (new waitForm())
            {
                var rpt = new rptVendorWiseSale(dtp.Value.Date, type);
                rpt.CreateDocument();
                ShowReport(rpt);
            }

        }

        private void ShowRecoveryReport()
        {
            using (new waitForm())
            {
                var rpt = new rptCustomerRecovery(dtp.Value.Date);

                rpt.CreateDocument();
                var frm = new XtraForm1(rpt);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void ShowTopCommissionReport()
        {
            using (new waitForm())
            {
                var rpt = new rptTopCommsissionReport(dtp.Value.Date, dtp2.Value.Date);
                rpt.CreateDocument();
                ShowReport(rpt);
            }
        }

        private void ShowMonthlyIncomeReport()
        {


            using (new waitForm())
            {
                var rpt = new rptMonthlyIncome(dtp.Value.Date, dtp2.Value.Date);
                rpt.CreateDocument();
                ShowReport(rpt);
            }
        }

        private void ShowKhasraSummary()
        {
            var frm = new frmKhasraSummary(dtp.Value.Date);
            frm.Show();
        }

        private void ShowKhasra()
        {
            var rpt = new rptKhasraDetails(dtp.Value.Date);
            ShowReport(rpt);
        }

        private void ShowCustomerSale()
        {
            using (new waitForm())
            {
                var data = new db().Query<vw_CustomerSale>($@" SELECT 
    [ArrivalDate],
    [ArrivalNo],
    [VendorName],
    [CustomerName],
    [ItemTitle],
    [ItemQty],
    [ItemWeight],
    [CustomerRate],
    [CustomerAmount],
    [LagaAmount]
FROM 
    [vw_CustomerSale]
WHERE 
    [ArrivalDate] = '{dtp.Value.Date:yyyy-MM-dd}'
ORDER BY 
    CASE WHEN CustomerName LIKE N'نقد سیل%' THEN 0 ELSE 1 END,
    SUM([CustomerAmount] + [LagaAmount]) OVER (PARTITION BY [CustomerName]) DESC").ToDataTable();
                bool isWeighted = data.Compute("Sum(ItemWeight)", "").toDecimal() != 0;
                if (isWeighted)
                {
                    var rpt = new rptCustomerSale(dtp.Value.Date, data);
                    rpt.CreateDocument();
                    ShowReport(rpt);
                }
                else
                {
                    var rpt = new rptCustomerSale2(dtp.Value.Date, data);
                    rpt.CreateDocument();
                    ShowReport(rpt);
                }


            }
        }

        private void ShowReport(XtraReport rpt, float zoom = 1.5f)
        {
            if (rpt == null) return;
            var frm = new XtraForm1(rpt, zoom);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(); frm.BringToFront();
            return;
        }

        private void ShowVendorSale()
        {
            using (new waitForm())
            {
                var frm = new rptVendorSale(dtp.Value.Date, _pid.Text.Trim().toInt());
                ShowReport(frm);
            }
        }

        private void ShowCustomerBill()
        {
            using (new waitForm())
            {
                var rpt = new CustomerBill(_pid.Text.toInt(), dtp.Value.Date);
                rpt.CreateDocument();
                ShowReport(rpt);
            }
        }

        private void ShowChitha(int ChithaType)
        {
            using (new waitForm())
            {
                string cities = string.Empty;
                string groups = string.Empty;
                // if (ChithaType == 1)
                {
                    groups = string.Join(",",
            cmbGroups?.CheckedItems?
                .Cast<MasterAccounts>()
                .Where(acc => acc != null && acc.ID != null)
                .Select(acc => acc.ID.ToString()) ?? Enumerable.Empty<string>());
                }
                // else if (ChithaType == 2)
                {
                    cities = string.Join(",",
                cmbCity?.CheckedItems?
                    .Cast<tblCity>()
                    .Where(acc => acc != null && acc.ID != null)
                    .Select(acc => acc.ID.ToString()) ?? Enumerable.Empty<string>());
                }
                string surfix = "چٹھہ جات";
                string prefix = "مکمل";
                if (!string.IsNullOrEmpty(groups) && string.IsNullOrEmpty(cities))
                {
                    prefix = "گروپ وار";
                }
                else if (!string.IsNullOrEmpty(cities) && string.IsNullOrEmpty(groups))
                {
                    prefix = "شہر وار";
                }
                else if (!string.IsNullOrEmpty(cities) && !string.IsNullOrEmpty(groups))
                {
                    prefix = "گروپ وار / شہر وار";
                }
                string title = $"{prefix} {surfix}";


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
        eb.EndBalance , Case When Cast(Acc.OldAccountCode as Nvarchar(50))='0' then '' Else Acc.OldAccountCode End As OldAccountCode, Acc.IsActive,acc.MasterID
    FROM EndBalances eb 
    LEFT JOIN DetailAccounts acc ON eb.AccountID = acc.ID 
    left Join MasterAccounts mas ON acc.MasterID = mas.ID
    LEFT JOIN tblCity city ON acc.CityID = city.ID
    WHERE MasterID Not IN (11,12) and (acc.AccountTitle Not Like N'نقد سیل') and acc.MasterID<>10 {(string.IsNullOrEmpty(groups) ? "" : $" and acc.MasterID in ({groups})")} {(string.IsNullOrEmpty(cities) ? "" : $" and city.ID in ({cities})")};";
                string sql2 = $@"WITH EndBalances AS
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
        eb.EndBalance , Case When Cast(Acc.OldAccountCode as Nvarchar(50))='0' then '' Else Acc.OldAccountCode End As OldAccountCode, Acc.IsActive,acc.MasterID
    FROM EndBalances eb 
    LEFT JOIN DetailAccounts acc ON eb.AccountID = acc.ID 
    left Join MasterAccounts mas ON acc.MasterID = mas.ID
    LEFT JOIN tblCity city ON acc.CityID = city.ID
    WHERE MasterID IN (11,12) and (acc.AccountTitle Not Like N'نقد سیل') and acc.MasterID<>10 {(string.IsNullOrEmpty(groups) ? "" : $" and acc.MasterID in ({groups})")} {(string.IsNullOrEmpty(cities) ? "" : $" and city.ID in ({cities})")};";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                using (var db = new db())
                {
                    var reader = db.ExecuteReader(sql);
                    dt.Load(reader);
                    var reader2 = db.ExecuteReader(sql2);
                    dt2.Load(reader2);
                }
                if (dt.Rows.Count > 0 || dt2.Rows.Count > 2)
                {
                    var report = new rptChithaFull(dt, dtp.Value.ToString("dd/MM/yyyy"), cmbSort.SelectedValue.toInt(), cmbType.SelectedValue.toInt(), title, dt2);
                    report.CreateDocument();
                    ShowReport(report, 1.5f);
                }
                else
                {
                    this.Info("کوئی ریکارڈ موجود نہیں ہے۔");
                }
            }

        }

        private void ShowLedger(int reportType)
        {
            if (_pid.Text.Trim().toInt() == 0)
            {
                this.Error("پارٹی کھاتہ منتخب کریں۔");
                _pname.Select();
                return;
            }

            using (new waitForm())
            {
                var acc = DetailAccounts.GetAccountByID(_pid.Text.Trim().toInt());
                if (acc == null)
                {
                    General.Error(null, "Account not found.");
                    return;
                }
                System.Collections.Generic.List<clsLedger> result = new db().Query<clsLedger>("sp_Ledger", new { AccountID = _pid.Text.toInt(), StartDate = dtp.Value.Date, EndDate = dtp2.Value.Date },
             commandType: CommandType.StoredProcedure).ToList<clsLedger>();

                System.Collections.Generic.List<clsLedger> FinalData = result;
                if (reportType == 1)
                {
                    switch (acc.MasterID)
                    {
                        case 4: //vendor
                                // 1️⃣ Group Credit Entries
                            var creditGrouped4 = result
                                .Where(x => x.Credit != 0)
                                .GroupBy(x => new { x.VoucherDate.Date, x.VoucherType, x.VoucherTitle })
                                .Select(g => new clsLedger
                                {
                                    VoucherDate = g.Key.Date,
                                    TrxType = g.First().TrxType,
                                    VoucherType = g.First().VoucherType,
                                    BillNo = g.First().BillNo,
                                    Narration = string.Join(", ", g.Select(x => x.Narration).Where(n => !string.IsNullOrWhiteSpace(n))),
                                    Debit = g.Sum(x => x.Debit),
                                    Credit = g.Sum(x => x.Credit),
                                    Balance = 0
                                });

                            // 2️⃣ Keep Debit-Only Entries As-Is
                            var debitOnly4 = result
                                .Where(x => x.Credit == 0 && x.Debit != 0)
                                .Select(x => new clsLedger
                                {
                                    VoucherDate = x.VoucherDate.Date,
                                    TrxType = x.TrxType,
                                    VoucherType = x.VoucherType,
                                    BillNo = x.BillNo,
                                    Narration = x.Narration,
                                    Debit = x.Debit,
                                    Credit = 0,
                                    Balance = 0
                                });

                            // 3️⃣ Combine Both Sets
                            System.Collections.Generic.List<clsLedger> combined4 = creditGrouped4
                                .Concat(debitOnly4)
                                .OrderBy(x => x.VoucherDate)
                                .ThenBy(x => x.BillNo)
                                .ToList();

                            // 4️⃣ Calculate Running Balance
                            decimal runningBalance4 = 0;
                            foreach (var item in combined4)
                            {
                                runningBalance4 += item.Debit - item.Credit;
                                item.Balance = runningBalance4;
                            }
                            FinalData = combined4;
                            break;
                        case 7: //Customer
                            var debitGrouped7 = result
                        .Where(x => x.Debit != 0)
                        .GroupBy(x => new { x.VoucherDate.Date, x.VoucherTitle })
                        .Select(g => new clsLedger
                        {
                            VoucherDate = g.Key.Date,
                            TrxType = g.First().TrxType,
                            VoucherType = g.First().VoucherType,
                            BillNo = g.First().BillNo,
                            Narration = string.Join(", ", g.Select(x => x.Narration).Where(n => !string.IsNullOrWhiteSpace(n))),
                            Debit = g.Sum(x => x.Debit),
                            Credit = g.Sum(x => x.Credit),
                            Balance = 0
                        });

                            // 2️⃣ Keep Credit-Only Entries As-Is
                            var creditOnly7 = result
                                .Where(x => x.Debit == 0 && x.Credit != 0)
                                .Select(x => new clsLedger
                                {
                                    VoucherDate = x.VoucherDate.Date,
                                    TrxType = x.TrxType,
                                    VoucherType = x.VoucherType,
                                    BillNo = x.BillNo,
                                    Narration = x.Narration,
                                    Debit = 0,
                                    Credit = x.Credit,
                                    Balance = 0
                                });

                            // 3️⃣ Combine Both Sets
                            var combined7 = debitGrouped7
                                .Concat(creditOnly7)
                                .OrderBy(x => x.VoucherDate)
                                .ThenBy(x => x.BillNo)
                                .ToList();

                            // 4️⃣ Calculate Running Balance
                            decimal runningBalance7 = 0;
                            foreach (var item in combined7)
                            {
                                runningBalance7 += item.Debit - item.Credit;
                                item.Balance = runningBalance7;
                            }
                            FinalData = combined7;
                            break;
                    }
                }


                var frm = new frmLedgerReport(FinalData, _pid.Text.Trim().toInt(), dtp.Value.Date, dtp2.Value.Date, reportType, acc.MasterID);
                frm.Show();
            }
        }

        private void _pname_Leave(object sender, System.EventArgs e)
        {
            if (!dgvHelp.Focused)
            {
                dgvHelp.Hide();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
