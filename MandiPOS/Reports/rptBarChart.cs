using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptBarChart : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBarChart(List<ChartData> data)
        {
            InitializeComponent();
            this.DataSource = data;
           // ConfigureChart(data);
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
