
using Dapper;
using MandiPOS.CLasses;
using System;
using System.Data;

namespace MandiPOS.Reports
{
    public partial class rptVendorWiseSale : DevExpress.XtraReports.UI.XtraReport
    {
        /// <summary>
        /// The main entry point for the application.
        /// type 0=All,1=Cash Sale, 2=Credit Sale
        /// </summary>
        public rptVendorWiseSale(DateTime date, int type = 0)
        {
            InitializeComponent();
            string sql = $@"Select * from vendorWiseSale Where ArrivalDate='{date:yyyy-MM-dd}'";
            var data = new db().Query<vendorWiseSale>(sql).ToDataTable();
            if (type == 1)
            {
                lblTitle.Text = $"بکری نقد";
                bndCustomer.Visible = false;
                if (data.Rows.Count > 0)
                {
                    var filteredRows = data.Select("CustomerAccountFull Like '%نقد سیل%'");

                    if (filteredRows != null && filteredRows.Length > 0)
                    {
                        var records = filteredRows.CopyToDataTable();
                        this.DataSource = records;
                    }
                    else
                    {
                        // No matching rows found
                        this.DataSource = null; // or assign an empty DataTable
                    }
                }

                else
                {
                    this.DataSource = null;
                }

                    
            }
            else if (type == 2)
            {
                lblTitle.Text = $"بکری ادھار";
                if (data.Rows.Count > 0)
                {
                    var filteredRows = data.Select("CustomerAccountFull Not Like '%نقد سیل%'");

                    if (filteredRows != null && filteredRows.Length > 0)
                    {
                        var records = filteredRows.CopyToDataTable();
                        this.DataSource = records;
                    }
                    else
                    {
                        // No matching rows found
                        this.DataSource = null; // or assign an empty DataTable
                    }
                }
                else
                {
                    this.DataSource = null;
                }
                    
            }
            else { this.DataSource = data; }


            lblDate.Text = $@"{date:dd-MMM-yyyy}";
        }

    }
}
