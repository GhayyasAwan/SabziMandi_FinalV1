using Dapper;

using Janus.Windows.GridEX;

using MandiPOS.CLasses;
using MandiPOS.GUI;
using MandiPOS.Reports.ReportClasses;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static MandiPOS.SQL;

namespace MandiPOS.Reports
{
    public partial class frmLedgerReport : Form
    {
        clsResize objres;
        DateTime d1 = DateTime.Today;
        DateTime d2 = DateTime.Today;
        int partyID = 0;
        List<clsLedger> data;
        int reportTyype;
        int MasterID = 0;
        string summary = string.Empty;


        public frmLedgerReport(List<clsLedger> _data, int PartyID, DateTime date, DateTime date1, int reportType, int masterID)
        {
            InitializeComponent();
            MasterID = masterID;
            uiComboBox1.SelectedIndex = 0;
            uiComboBox1.SelectedIndexChanged += UiComboBox1_SelectedIndexChanged;
            data = _data;
            reportTyype = reportType;
            d1 = date; d2 = date1;
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
            if (acc.MasterID != 4)
            {
                dgvLedger.RootTable.Columns["BillNo"].Selectable = false;
                dgvLedger.RootTable.Columns["BillNo"].SelectableCells = SelectableCells.None;
            }
            summary = new db().QuerySingle<string>($"Select dbo.fn_GetPartyItemSummary('{date}','{date1}',{PartyID}) as summary");
            lblSummary.Text = summary?.ToString();
        }

        private void UiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex == 0) //Complete
            {
                clsLedgerBindingSource.DataSource = data;
                dgvLedger.RootTable.Columns["Balance"].Visible = true;
                dgvLedger.RootTable.Columns["Credit"].Visible = true;
                dgvLedger.RootTable.Columns["Debit"].Visible = true;
                dgvLedger.RootTable.Columns["Status"].Visible = true;
            }
            else if (uiComboBox1.SelectedIndex == 1) //
            {
                var filteredData = data.Where(x => x.Debit != 0).ToList();
                dgvLedger.RootTable.Columns["Balance"].Visible = false;
                dgvLedger.RootTable.Columns["Credit"].Visible = false;
                dgvLedger.RootTable.Columns["Debit"].Visible = true;
                dgvLedger.RootTable.Columns["Status"].Visible = false;
                clsLedgerBindingSource.DataSource = filteredData;
            }
            else if (uiComboBox1.SelectedIndex == 2)
            {
                var filteredData = data.Where(x => x.Credit != 0).ToList();
                dgvLedger.RootTable.Columns["Balance"].Visible = false;
                dgvLedger.RootTable.Columns["Credit"].Visible = true;
                dgvLedger.RootTable.Columns["Debit"].Visible = false;
                dgvLedger.RootTable.Columns["Status"].Visible = false;
                clsLedgerBindingSource.DataSource = filteredData;
            }
            clsLedgerBindingSource.ResetBindings(false);
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
                if (MasterID != 4)
                {
                    Console.Beep(2000, 50);
                    return;
                }
                var entry = dgvLedger.CurrentRow.DataRow as clsLedger;

                if (entry.TrxType != 4)
                {
                    Console.Beep(2000, 50);
                    return;
                }
                using (new crsr())
                {
                    string billNo = dgvLedger.CurrentRow.Cells["BillNo"].Value.ToString();
                    using (var rpt = new saleBill(billNo, 1))
                    {
                        rpt.CreateDocument();
                        using (var frm = new XtraForm1(rpt, true))
                        {
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.WindowState = FormWindowState.Normal;
                            Size s = frm.Size;
                            frm.Size = new Size(794, s.Height);
                            frm.ShowDialog(this);
                        }
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
            if (reportTyype != 0)
            {
                var showdetails = this.Ask("کیا آپ تفصیل بھی پرنٹ  کرناچاہتے ہیں؟");
                if (!showdetails)
                {
                    foreach (clsLedger item in data)
                    {
                        if (MasterID == 4 && item.Credit != 0)
                        {
                            item.Narration = string.Empty;
                        }
                        if (MasterID != 4 && item.Debit != 0)
                        {
                            item.Narration = string.Empty;
                        }
                    }
                }
            }
            if (uiComboBox1.SelectedIndex == 0)
            {
                var report = new rptPartyLedger(d1.ToString("dd-MMM-yy"), d2.ToString("dd-MMM-yy"), partyID, data, reportTyype);
                var frm = new XtraForm1(report);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            else if (uiComboBox1.SelectedIndex == 1)
            {
                var filteredData = data.Where(x => x.Debit != 0).ToList();
                var report = new rptPartyLedgerBanam(d1.ToString("dd-MMM-yy"), d2.ToString("dd-MMM-yy"), partyID, filteredData, reportTyype);
                var frm = new XtraForm1(report);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            else if (uiComboBox1.SelectedIndex == 2)
            {
                var filteredData = data.Where(x => x.Credit != 0).ToList();
                var report = new rptPartyLedgerJama(d1.ToString("dd-MMM-yy"), d2.ToString("dd-MMM-yy"), partyID, filteredData, reportTyype);
                var frm = new XtraForm1(report);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }
    }
}
