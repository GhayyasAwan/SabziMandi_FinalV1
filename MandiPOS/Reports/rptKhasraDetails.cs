using Dapper;
using MandiPOS.CLasses;
using System;

namespace MandiPOS.Reports
{
    public partial class rptKhasraDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public rptKhasraDetails(DateTime date)
        {
            InitializeComponent();
            var data = new db().Query<vw_KhasraDetails>($@"Select * from vw_KhasraDetails where ArrivalDate='{date:yyyy-MM-dd}'  Order By CASE WHEN AccountTitle LIKE N'%نقد سیل' THEN 0 ELSE 1 END,
    TotalAmount DESC").ToDataTable();
            decimal naqad = data.Compute("Sum(TotalAmount)", "AccountTitle LIKE '%نقد سیل%'").toDecimal();
            decimal udhar = data.Compute("Sum(TotalAmount)", "AccountTitle Not LIKE '%نقد سیل%'").toDecimal();
            lblnaqad.Text = naqad.ToString("N0");
            lbludhar.Text = udhar.ToString("N0");
            this.DataSource = data;
            lblDate.Text = $@"{date:dd-MM-yyyy}";
        }

    }
}
