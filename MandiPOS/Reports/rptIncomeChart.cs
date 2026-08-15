using Dapper;

using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;

using static MandiPOS.SQL;

namespace MandiPOS.Reports
{
    public partial class rptIncomeChart : DevExpress.XtraReports.UI.XtraReport
    {
        public rptIncomeChart(DateTime date1, DateTime date2)
        {
            InitializeComponent();
            string sql = $@"SELECT [MonthTag],
                  Round(Sum([Laga]+[Commission]+[Mazdoori]+[Munshiana]),0) as 'TotalAmount' FROM [vw_SaleItemCostDistribution]
            where ArrivalDate Between '{date1:yyyy-MM-dd}' and '{date2:yyyy-MM-dd}'
            	  Group By MonthTag";
            var chartData = new db().Query<ChartData>(sql).ToDataTable();
            this.DataSource = chartData;


            //XtraReport report = new XtraReport();
            // report.DataSource = chartData; // your datatable with MonthTag & TotalAmount

            XRChart chart = new XRChart();
            chart.DataSource = chartData;

            Series series = new Series("Monthly Amount", ViewType.Bar);
            series.ArgumentDataMember = "MonthTag";
            series.ValueDataMembers.AddRange(new string[] { "TotalAmount" });

            chart.Series.Add(series);

            // Add chart to report header
            this.Bands[BandKind.ReportHeader].Controls.Add(chart);


        }

    }
}
