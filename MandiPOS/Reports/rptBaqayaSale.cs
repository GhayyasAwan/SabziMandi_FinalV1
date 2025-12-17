using Dapper;
using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using System;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptBaqayaSale : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBaqayaSale(object data, string daterange, int partyid)
        {
            InitializeComponent();
            
            this.HideWarnings();
            var header =new rptHeader(partyid);
            header.CreateDocument();    
            this.xrSubreport1.ReportSource = header;

            this.DataSource = data;
            this.lblDate.Text = $@"{daterange}";
            this.lbl2.Text = $@"Print on: {DateTime.Now.Date:dd-MMM-yyyy hh:mm tt}";
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private static void SetValueFormat(object sender)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null)
            {
                // Check if the value is 0 (you might need to handle different numeric types)
                if (cell.Text == "0" || cell.Text == "0.00" || cell.Text == "0.0")
                {
                    cell.Text = "";
                }
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell9_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell10_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell11_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        private void xrTableCell12_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetValueFormat(sender);
        }

        
    }
}
