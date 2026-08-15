

using Dapper;
using MandiPOS.CLasses;

using System;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptMasterSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMasterSheet(int PartyID, DateTime d1, DateTime d2)
        {
            InitializeComponent();
            string sql = $@"SELECT
		ArrivalDate
	 ,ArrivalNo
	 ,ItemTitle
	,PartyID
	 ,SUM(ItemQty) AS ItemQty
	 ,SUM(Commission) AS Commission
	 ,SUM(MS.Mazdoori) AS Mazdoori
	 ,SUM(Munshiana) AS Munshiana
	 ,SUM(PartyAmount) AS PartyAmount,SUM(CustomerAmount) AS CustomerAmount
		,SUM(MS.Karaya) AS Karaya
		,Sum(Netpaid) as Netpaid
		,Marka
	FROM dbo.MasterSheet MS Where PartyID='{PartyID}' and ArrivalDate between '{d1:yyyy-MM-dd}' and '{d2:yyyy-MM-dd}' Group BY ItemTitle, ArrivalNo, ArrivalDate, PartyID, Marka";
            var data = new db().Query<MasterSheet>(sql).ToList();
            var acc = DetailAccountService.GetDetailAccountByID(PartyID);
            _party.Text = acc.AccountTitle;
            _d1.Text = $"{d1:dd-MMM-yyyy}"; _d2.Text = $"{d2:dd-MMM-yyyy}";
            string summary = new db().QuerySingle<string>($"Select dbo.fn_GetPartyItemSummary('{d1:yyyy-MM-dd}','{d2:yyyy-MM-dd}',{PartyID}) as summary");
            this.objectDataSource1.DataSource = data;
            lblSummary.Text = summary;
        }
    }
}
