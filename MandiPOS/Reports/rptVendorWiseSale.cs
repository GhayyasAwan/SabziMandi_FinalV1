using Dapper;

using System;
using System.Data;

using static MandiPOS.SQL;

namespace MandiPOS.Reports
{
    public partial class rptVendorWiseSale : DevExpress.XtraReports.UI.XtraReport
    {
        /// <summary>
        /// The main entry point for the application.
        /// type 0=All,1=Cash Sale, 2=Credit Sale
        /// </summary>
        public rptVendorWiseSale(DateTime date, int type = 0, DataTable data = null)
        {
            InitializeComponent();
            string summary = "";
            if (type == 1)
            {
                lblTitle.Text = $"بکری نقد";
                bndCustomer.Visible = false;
                var records = data.Select("CustomerAccountFull Like '%نقد سیل%'").CopyToDataTable();
                this.DataSource = records;
                summary = new db().QuerySingle<string>($"Select dbo.fn_GetPartyItemSummary2('{date:yyyy-MM-dd}') as summary");
            }
            else if (type == 2)
            {
                lblTitle.Text = $"بکری ادھار";

                var records = data.Select("CustomerAccountFull Not Like '%نقد سیل%'").CopyToDataTable();
                this.DataSource = records;
            }
            else { this.DataSource = data; }


            lblDate.Text = $@"{date:dd-MMM-yyyy}";
            lblSummary.Text = summary;
        }

    }
}
