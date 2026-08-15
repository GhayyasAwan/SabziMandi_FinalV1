
using MandiPOS.CLasses;
using System;
using System.Data;

namespace MandiPOS.Reports
{
    public partial class rptCustomerSale2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCustomerSale2(DateTime date,DataTable data)
        {
            InitializeComponent();
            decimal naqad = data.Compute("Sum(FinalAmount)", "CustomerName LIKE '%نقد سیل%'").toDecimal();
            decimal udhar = data.Compute("Sum(FinalAmount)", "CustomerName Not LIKE '%نقد سیل%'").toDecimal();
            lblnqd.Text = naqad.ToString("0.##");
            lbludhar.Text = udhar.ToString("0.##");
            lblDate.Text = date.ToString("dd-MMM-yyyy");
            this.DataSource = data;
        }

        private void xrTableCell38_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void xrTableCell35_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
