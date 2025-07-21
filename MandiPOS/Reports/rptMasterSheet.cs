using Dapper;

using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptMasterSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMasterSheet(int PartyID, DateTime d1, DateTime d2)
        {
            InitializeComponent();
            string sql = $"Select * from MasterSheet Where PartyID='{PartyID}' and ArrivalDate between '{d1:yyyy-MM-dd}' and '{d2:yyyy-MM-dd}'";
            var data = new db().Query<MasterSheet>(sql).ToList();
            var acc=DetailAccountService.GetDetailAccountByID(PartyID);
            _party.Text=acc.AccountTitle;
            _d1.Text = $"{d1:dd-MMM-yyyy}"; _d2.Text = $"{d2:dd-MMM-yyyy}";
            this.objectDataSource1.DataSource = data;
        }
    }
}
