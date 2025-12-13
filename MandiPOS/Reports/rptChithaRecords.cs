using System;

namespace MandiPOS.Reports
{
    public partial class rptChithaRecords : DevExpress.XtraReports.UI.XtraReport
    {
        public rptChithaRecords(string type = "", int sortOrder = 0)
        {
            InitializeComponent();
            lblrqm.Text = $"رقم {type}";
            lblTotal.Text = $"کُل {type}";
            
        }

        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal value = xrTableCell1.Text.toDecimal();
            if (value < 0)
            {
                xrTableCell1.Text = Math.Abs(value).ToString("N0");
                xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            }
            else
            {
                xrTableCell1.Text = value.ToString("N0");
                xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            }
        }
    }
}
