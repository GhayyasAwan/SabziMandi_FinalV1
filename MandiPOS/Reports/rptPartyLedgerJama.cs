using Dapper;

using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;
using MandiPOS.Reports.ReportClasses;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptPartyLedgerJama : DevExpress.XtraReports.UI.XtraReport
    {
        int rType = 0;
        public rptPartyLedgerJama(string date1,string date2,int PartyID, List<clsLedger> data, int ReportType=0)
        {
            InitializeComponent();
            lblDate1.Text = date1;
            lblDate2.Text = date2;
            rType = ReportType;
            DetailAccounts acc=new DetailAccounts();
            using (var db = new db())
                acc = db.Get<DetailAccounts>(PartyID);
            var rpt=new rptHeader(PartyID);
            rpt.CreateDocument();
            this.xrSubreport1.ReportSource = rpt;
            decimal totalBanam = 0, TotalJama=0, endBalance=0;
            TotalJama = data.Sum(x => x.Credit);
            totalBanam = data.Sum(x => x.Debit);
            endBalance = totalBanam - TotalJama;
            //_endBal.Text = Math.Abs(endBalance).ToString("#,0.##");
            if (endBalance >= 0)
            {
               // _endSate.Text = "بنام";
            }
            else
            {
               // _endSate.Text = "جمع";
            }
            if (ReportType == 1)
            {
                xrLabel1.Text = "فرد حساب";
            }
            this.DataSource = data;
            string summary = new db().QuerySingle<string>($"Select dbo.fn_GetPartyItemSummary('{date1}','{date2}',{PartyID}) as summary");
            lblSummary.Text = summary;
        }

        private void xrTableCell8_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value.toDecimal() == 0 || cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell9_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value.toDecimal() == 0 || cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
        }

        private void xrLabel2_BeforePrint(object sender, CancelEventArgs e)
        {
            XRLabel cell = sender as XRLabel;
            if (cell.Value.toDecimal() == 0 || cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
        }

        private void xrLabel3_BeforePrint(object sender, CancelEventArgs e)
        {
            XRLabel cell = sender as XRLabel;
            if (cell.Value.toDecimal() == 0 || cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell14_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value.toDecimal() == 0 || cell.Text == "0")
            {
                cell.Text = string.Empty;
            }
            if (cell.Value.toDecimal() < 0)
            { 
                cell.Text=Math.Abs(cell.Value.toDecimal()).ToString("N0");
            }
        }

        private void _endBal_BeforePrint(object sender, CancelEventArgs e)
        {
            //XRTableCell cell = sender as XRTableCell;
            //if (cell.Value.toDecimal() == 0 || cell.Text == "0")
            //{
            //    cell.Text = string.Empty;
            //}
        }

        private void xrTableRow1_BeforePrint(object sender, CancelEventArgs e)
        {
            
        }

        private void xrTableRow2_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableRow row = sender as XRTableRow;
            decimal credit = Convert.ToDecimal(GetCurrentColumnValue("Credit"));
            decimal debit = Convert.ToDecimal(GetCurrentColumnValue("Debit"));

            if (credit >= 0 && debit == 0)
            {
                row.ForeColor = Color.Green;
                // row.BackColor = Color.LightGreen; // optional
            }
            else if (debit >= 0 && credit == 0)
            {
                row.ForeColor = Color.Red;
            }
            else { row.ForeColor = Color.Black; }
        }

        private void xrTable2_BeforePrint(object sender, CancelEventArgs e)
        {
            if (rType==1)
            {
                XRTableRow row = xrTableRow1;
                XRTableCell cellToRemove = row.Cells.Cast<XRTableCell>()
                            .FirstOrDefault(c => c.Name == "xrTableCell13");

                if (cellToRemove != null)
                {
                    row.Cells.Remove(cellToRemove);
                } 
            }


        }
    }
}
