using Dapper;

using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Linq;

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
            List<vw_SaleItemCostDistribution> data = new db().Query<vw_SaleItemCostDistribution>(sql).ToList();
            var ChartData = ConvertToChartData(data);
            ConfigureChart(ChartData);
            this.DataSource = data.ToDataTable();
            var rpt = new rptIncomeChart(date1, date2);
            rpt.CreateDocument();
        }
        public List<ChartData> ConvertToChartData(List<vw_SaleItemCostDistribution> saleData)
        {
            var chartData = saleData
                .GroupBy(x => x.MonthTag) // Group by MonthTag (like "Jan-2025")
                .Select(g => new ChartData
                {
                    MonthTag = g.First().UrduMonthName, // Use Urdu month name for display
                    TotalAmount = g.Sum(x => x.TotalAmount) // Sum TotalAmount for each group
                })
                .ToList();
            return chartData;
        }
        private void ConfigureChart(List<ChartData> data)
        {
            // Clear existing series
            xrChart1.Series.Clear();

            // Create and configure series
            Series series = new Series("", ViewType.Bar); // Empty series name
            foreach (var d in data)
            {
                series.Points.Add(new SeriesPoint(d.MonthTag, d.TotalAmount));
            }

            // Hide all legends and titles
            xrChart1.Legend.Visibility = DefaultBoolean.False;
            series.ShowInLegend = false;

            // Add series to chart
            xrChart1.Series.Add(series);

            // Make chart full width
            xrChart1.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right - 20; // Little padding
            xrChart1.AnchorVertical = VerticalAnchorStyles.Top;
            xrChart1.AnchorHorizontal = HorizontalAnchorStyles.Left | HorizontalAnchorStyles.Right;

            // Configure diagram
            XYDiagram diagram = (XYDiagram)xrChart1.Diagram;

            // Axis titles
            diagram.AxisY.Title.Text = "Amount";
            diagram.AxisX.Title.Text = "Month";

            // Label formatting
            diagram.AxisX.Label.Angle = -45;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = true;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = true;

            // Adjust bar appearance
            BarSeriesView barView = (BarSeriesView)series.View;
            barView.BarWidth = 0.5;
            barView.ColorEach = true; // Different colors for each bar

            // Enable data labels on bars
            series.LabelsVisibility = DefaultBoolean.True;
            series.Label.TextPattern = "{V:#,##0}"; // Format numbers

            // Adjust chart padding
            diagram.AxisX.Visible = true;
            diagram.AxisY.Visible = true;
        }

    }

}
