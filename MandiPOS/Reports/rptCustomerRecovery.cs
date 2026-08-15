using Dapper;

using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;
using System.Linq;

using static MandiPOS.SQL;

namespace MandiPOS.Reports
{
    public partial class rptCustomerRecovery : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCustomerRecovery(DateTime date)
        {
            InitializeComponent();

            this.HideWarnings();
            string sql = $@"DECLARE @SelectedDate DATE = '{date:yyyy-MM-dd}';

SELECT 
    t.AccountID,
    acc.AccountCode,
    acc.AccountTitle,
    ISNULL(SUM(CASE WHEN VoucherDate < @SelectedDate THEN DebitAmount - CreditAmount END), 0) AS PreviousBalance,
    ISNULL(SUM(CASE WHEN VoucherDate = @SelectedDate THEN DebitAmount END), 0) AS TodayDebit,
    ISNULL(SUM(CASE WHEN VoucherDate = @SelectedDate THEN CreditAmount END), 0) AS TodayCredit,
    ISNULL(SUM(CASE WHEN VoucherDate <= @SelectedDate THEN DebitAmount - CreditAmount END), 0) AS CurrentBalance,
    MAX(VoucherDate) AS LastDate,
    -- Added for sorting
    CASE WHEN ISNULL(SUM(CASE WHEN VoucherDate = @SelectedDate THEN DebitAmount END), 0) > 0 THEN 1 ELSE 0 END AS HasTodayDebit
FROM vwTrx t
LEFT JOIN DetailAccounts acc ON t.AccountID = acc.ID
WHERE acc.MasterID = 7 and acc.AccountCode <> 70190
GROUP BY t.AccountID, acc.AccountCode, acc.AccountTitle
HAVING 
    --ISNULL(SUM(CASE WHEN VoucherDate = @SelectedDate THEN DebitAmount + CreditAmount END), 0) <> 0
    ISNULL(SUM(DebitAmount-CreditAmount),0) <> 0  OR MAX(VoucherDate) = @SelectedDate
ORDER BY 
    HasTodayDebit DESC,  -- Accounts with TodayDebit > 0 first
    LastDate DESC,      -- Then sort by date descending within each group
    AccountCode         -- Secondary sort for consistent ordering";
            System.Collections.Generic.List<AccountBalanceSummary> data = new db().Query<AccountBalanceSummary>(sql).ToList();
            var toRemove = data
     .Where(x => x.CurrentBalance < 0 && x.LastDate.Date < DateTime.Today)
     .ToList();

            var accountBalanceList = data
                .Where(x => !(x.CurrentBalance <= 0 && x.LastDate.Date < date.Date))
                .ToList();
            //System.Collections.Generic.List<AccountBalanceSummary> data2 = new System.Collections.Generic.List<AccountBalanceSummary>();
            //foreach (var item in data)
            //{ 

            //}
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
