using Dapper;
using MandiPOS.CLasses;
using System;

namespace MandiPOS.Reports
{
    public partial class rptVendorSale : DevExpress.XtraReports.UI.XtraReport
    {
        public rptVendorSale(DateTime date)
        {
            InitializeComponent();
            var data = new db().GetList<vw_vendorSale>($"Where ArrivalDate='{date:yyyy-MM-dd}'");
            this.DataSource = data;
            xrLabel1.Text = $"{date:dd-MMM-yyyy}";
            string items = new db().ExecuteScalar<string>($"Select ItemDetails from vw_DateWiseItemsSummary Where ArrivalDate='{date:yyyy-MM-dd}'");
            lblItems.Text = items;

        }

    }
}
