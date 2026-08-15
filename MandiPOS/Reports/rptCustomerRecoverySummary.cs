

using Dapper;
using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;
using System.Data;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptCustomerRecoverySummary : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCustomerRecoverySummary(DateTime date)
        {
            InitializeComponent();
            this.HideWarnings();
            string sql = $@"exec usp_GetRecoveryReport '{date:yyyy-MM-dd}'";
            System.Collections.Generic.List<AccountBalanceSummary> data = new db().Query<AccountBalanceSummary>(sql).ToList();
            var toRemove = data
     .Where(x => x.CurrentBalance < 0 && x.LastDate.Date < DateTime.Today)
     .ToList();
            var accountBalanceList = data
                .Where(x => !(x.CurrentBalance <= 0 && x.LastDate.Date < date.Date))
                .ToList();

            this.DataSource = accountBalanceList;
            this.lblDate.Text = $@"{date:dd-MMM-yyyy}";
            this.lbl2.Text = $@"Print on: {DateTime.Now.Date:dd-MMM-yyyy hh:mm tt}";
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private static void SetValueFormat(object sender)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null)
            {
                // Check if the value is 0 (you might need to handle different numeric types)
                if (cell.Text == "0" || cell.Text == "0.00" || cell.Text == "0.0")
                {
                    cell.Text = "";
                }
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell9_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell10_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell11_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell12_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }


    }
}
