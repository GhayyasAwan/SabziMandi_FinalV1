using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using static MandiPOS.SQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Dapper;

namespace MandiPOS.Reports
{
    public partial class MarkaBill : DevExpress.XtraReports.UI.XtraReport
    {
        public MarkaBill(string PartyID, string date)
        {
            InitializeComponent();
            lblDate.Text = Convert.ToDateTime(date).Date.ToString("dddd, dd-MMM-yyyy");
            // System.Globalization ka istemal karte hue Urdu Culture apply kiya
            lblDate.Text = Convert.ToDateTime(date).ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("ur-PK"));
            DetailAccounts acc=DetailAccountService.GetDetailAccountByID(PartyID.toInt());
            if (acc.CustomLabel != null && acc.CustomLabel.Length > 0)
            {
                var stream = new MemoryStream(acc.CustomLabel);
                pb1.ImageSource = new ImageSource(false, acc.CustomLabel);
            }
            else
            {
                pb1.ImageSource = null;
            }
            this.DataSource = new db().Query<CLasses.MarkaWiseReport>($"Exec sp_GetPartySaleData2 '{Convert.ToDateTime(date).Date.ToString("yyyy-MM-dd")}',{PartyID}").ToList()??new List<MarkaWiseReport>();      
            this.HideWarnings();
            this.CreateDocument();
        }

        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
