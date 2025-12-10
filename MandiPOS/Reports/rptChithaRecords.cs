using System;

namespace MandiPOS.Reports
{
    public partial class rptChithaRecords : DevExpress.XtraReports.UI.XtraReport
    {
        string _type = "";
        public rptChithaRecords(string type = "", bool summaryOnly = false)
        {
            InitializeComponent();
            _type = type;
            lblrqm.Text = $"رقم {type}";
            lblTotal.Text = $"کُل {type}";
            xrTable1.Visible = !summaryOnly;
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

        private void xrTableCell14_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrTableCell14.Text = _type;
        }
    }
}
