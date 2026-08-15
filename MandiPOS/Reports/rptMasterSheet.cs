using Dapper;

using MandiPOS.CLasses;

using System;
using System.ComponentModel;
using System.Linq;

using static MandiPOS.SQL;

namespace MandiPOS.Reports
{
    public partial class rptMasterSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMasterSheet(int PartyID, DateTime d1, DateTime d2)
        {
            InitializeComponent();
            string sql = $"Select * from MasterSheet Where PartyID='{PartyID}' and ArrivalDate between '{d1:yyyy-MM-dd}' and '{d2:yyyy-MM-dd}'";
            var data = new db().Query<MasterSheet>(sql).ToList();
            var acc = DetailAccountService.GetDetailAccountByID(PartyID);
            _party.Text = acc.AccountTitle;
            _d1.Text = $"{d1:dd-MMM-yyyy}"; _d2.Text = $"{d2:dd-MMM-yyyy}";
            string summary = new db().QuerySingle<string>($"Select dbo.fn_GetPartyItemSummary('{d1:yyyy-MM-dd}','{d2:yyyy-MM-dd}',{PartyID}) as summary");
            this.objectDataSource1.DataSource = data;
            lblSummary.Text = summary;
        }

        private void rptMasterSheet_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
