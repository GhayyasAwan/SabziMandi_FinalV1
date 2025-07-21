using Dapper;
using MandiPOS.CLasses;
using System;

namespace MandiPOS.Reports
{
    public partial class rptMonthlyIncome : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMonthlyIncome(DateTime date1, DateTime date2)
        {
            InitializeComponent();
            lblDate1.Text = $@"{date1:dd-MM-yyyy}";
            lblDate2.Text = $@"{date2:dd-MM-yyyy}";
            string sql = $@"SELECT 
    [MonthTag],
    [ItemID],
    SUM([Laga]) AS Laga,
    SUM([Commission]) AS Commission,
    SUM([Mazdoori]) AS Mazdoori,
    SUM([Munshiana]) AS Munshiana
FROM [vw_SaleItemCostDistribution]
Where ArrivalDate Between '{date1:yyyy-MM-dd}' and '{date2:yyyy-MM-dd}'
GROUP BY [MonthTag], [ItemID]
ORDER BY 
    CAST(RIGHT([MonthTag], 4) AS INT),  -- Year first
    CASE LEFT([MonthTag], 3)             -- Then month
        WHEN 'Jan' THEN 1
        WHEN 'Feb' THEN 2
        WHEN 'Mar' THEN 3
        WHEN 'Apr' THEN 4
        WHEN 'May' THEN 5
        WHEN 'Jun' THEN 6
        WHEN 'Jul' THEN 7
        WHEN 'Aug' THEN 8
        WHEN 'Sep' THEN 9
        WHEN 'Oct' THEN 10
        WHEN 'Nov' THEN 11
        WHEN 'Dec' THEN 12
    END,
    [ItemID]";
            var data = new db().Query<vw_SaleItemCostDistribution>(sql).ToDataTable();

            this.DataSource = data;
            var rpt = new rptIncomeChart(date1, date2);
            rpt.CreateDocument();
            xrSubreport1.ReportSource = rpt;
        }

    }
}
