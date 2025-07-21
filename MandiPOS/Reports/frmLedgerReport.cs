using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;

using Janus.Windows.GridEX;
using MandiPOS.CLasses;
using MandiPOS.Reports.ReportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.Reports
{
    public partial class frmLedgerReport : Form
    {
        clsResize objres;
        DateTime d1=DateTime.Today;
        DateTime d2 = DateTime.Today;
        int partyID = 0;
        List<clsLedger> data;
        int reportTyype;


        public frmLedgerReport(List<clsLedger> _data, int PartyID, DateTime date, DateTime date1, int reportType)
        {
            InitializeComponent();
            data = _data;
            reportTyype = reportType;
            d1=date;d2=date1;
            partyID = PartyID;
            objres = new clsResize(this);
            this.Load += FrmLedgerReport_Load;
            this.Resize += FrmLedgerReport_Resize;
            this.Text = $"{date:dd-MMM-yyyy} to {date1:dd-MMM-yyyy}";
            var acc = DetailAccounts.GetAccountByID(PartyID);
            lblDateRange.Text = $"{date:dd-MMM-yyyy}";
            lblDateRange2.Text = $"{date1:dd-MMM-yyyy}";
            var city = SQL.GetCities().Where(x => x.ID == acc.CityID).FirstOrDefault().CityName;
            var group = MasterAccountsService.GetMasterAccounts($" Where ID='{acc.MasterID}'").FirstOrDefault().AccountTitle;
            lblCode.Text = acc.AccountCode.ToString();
            lblRemarks.Text = acc.Remarks?.ToString();
            lblCommission.Text = acc.Commission.ToString("0.##");
            label1.Text = $"{group}";
            lblTitle.Text = city + " " + acc.AccountTitle;
            lblCreditLimit.Text = acc.CreditLimit.ToString("0.##");
            lblcontact.Text = acc.Contact;
            lblRef.Text = acc.RefName;
            clsLedgerBindingSource.DataSource = data;
            dgvLedger.ColumnButtonClick += DgvLedger_ColumnButtonClick;
            dgvLedger.FormattingRow += DgvLedger_FormattingRow;

        }

        private void DgvLedger_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {


            if (e.Row.RowType == RowType.TotalRow)
            {
                decimal totalDebit = 0;
                decimal totalCredit = 0;

                if (decimal.TryParse(Convert.ToString(e.Row.Cells["Debit"]?.Value), out decimal debit))
                    totalDebit = debit;

                if (decimal.TryParse(Convert.ToString(e.Row.Cells["Credit"]?.Value), out decimal credit))
                    totalCredit = credit;

                decimal difference = totalDebit - totalCredit;

                e.Row.Cells["Balance"].Text = Math.Abs(difference).ToString("0.##");

                if (difference < 0)
                {
                    e.Row.Cells["Status"].Text = "جمع";
                }
                else
                {
                    e.Row.Cells["Status"].Text = "بنام";
                }
            }
        }

        private void DgvLedger_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (dgvLedger.IsRow() && !string.IsNullOrEmpty(dgvLedger.CurrentRow.Cells["BillNo"].Value.ToString()))
            {
                var entry = dgvLedger.CurrentRow.DataRow as clsLedger;

                if (entry.TrxType == 0)
                {
                    return; // No bill number to show
                }
                using (new crsr())
                {
                    string billNo = dgvLedger.CurrentRow.Cells["BillNo"].Value.ToString();
                    using (var rpt = new saleBill(billNo, 1))
                    {
                        rpt.CreateDocument();
                        rpt.ShowPreviewDialog();
                    }
                }
            }
        }

        private void FrmLedgerReport_Resize(object sender, System.EventArgs e)
        {
            //objres._resize();
        }

        private void FrmLedgerReport_Load(object sender, System.EventArgs e)
        {
            objres._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (!data.Any()) { return; }
             var report = new rptPartyLedger(d1.ToString("dd-MMM-yy"), d2.ToString("dd-MMM-yy"), partyID,data,reportTyype);
            ReportPrintTool tool=new ReportPrintTool(report);
           var frm=tool.PreviewForm;
            tool.ShowPreview();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();

        }
    }
}
