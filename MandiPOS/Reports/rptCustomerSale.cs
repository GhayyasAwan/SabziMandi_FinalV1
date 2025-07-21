using Dapper;
using MandiPOS.CLasses;
using System;

namespace MandiPOS.Reports
{
    public partial class rptCustomerSale : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCustomerSale(DateTime date)
        {
            InitializeComponent();
            var data = new db().Query<vw_CustomerSale>($@" SELECT 
    [ArrivalDate],
    [ArrivalNo],
    [VendorName],
    [CustomerName],
    [ItemTitle],
    [ItemQty],
    [ItemWeight],
    [CustomerRate],
    [CustomerAmount],
    [LagaAmount]
FROM 
    [vw_CustomerSale]
WHERE 
    [ArrivalDate] = '{date:yyyy-MM-dd}'
ORDER BY 
    CASE WHEN CustomerName LIKE N'نقد سیل%' THEN 0 ELSE 1 END,
    SUM([CustomerAmount] + [LagaAmount]) OVER (PARTITION BY [CustomerName]) DESC").ToDataTable();
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
