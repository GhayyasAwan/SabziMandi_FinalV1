using Dapper;

using MandiPOS.CLasses;

using System;

namespace MandiPOS.Reports
{
    public partial class rptVendorSale : DevExpress.XtraReports.UI.XtraReport
    {
        public rptVendorSale(DateTime date, int PartyID = 0)
        {
            InitializeComponent();
            var data = new db().Query<vw_vendorSale>($"Select * from vw_vendorSale Where ArrivalDate='{date:yyyy-MM-dd}' {(PartyID == 0 ? "" : $" and PartyID='{PartyID}'")}");
            this.DataSource = data;
            xrLabel1.Text = $"{date:dd-MMM-yyyy}";
            string items = new db().ExecuteScalar<string>($"Exec sp_GetItemsDetails '{date:yyyy-MM-dd}','{PartyID}'");
            lblItems.Text = items;
        }
    }
}
