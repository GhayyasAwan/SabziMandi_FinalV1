
using Dapper;
using MandiPOS.CLasses;
using System;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptTopCommsissionReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTopCommsissionReport(DateTime date1, DateTime date2)
        {
            InitializeComponent();
            var data = new db().Query<vw_CommissionReport>($"Select AccountCode,AccountTitle,Sum(CommissionAmount) as 'CommissionAmount' from vw_CommissionReport Where ArrivalDate between '{date1:yyyy-MM-dd}' and '{date2:yyyy-MM-dd}' Group By AccountCode,AccountTitle").OrderByDescending(x => x.CommissionAmount).ToDataTable();
            this.DataSource = data;
            lblDate1.Text = $@"{date1:dd-MM-yyyy}";
            lblDate2.Text = $@"{date2:dd-MM-yyyy}";
        }

    }
}
