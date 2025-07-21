using DevExpress.XtraReports.UI;

using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptMarkaSummary : DevExpress.XtraReports.UI.XtraReport
    {
        decimal endBalance = 0;
        public rptMarkaSummary(string marka,int PartyId, DateTime date1, DateTime date2, List<vw_vendorSale> data, string totalString)
        {
            InitializeComponent();
            lblDate1.Text = $"{date1:dd-MMM-yyyy}";
            lblDate2.Text = $"{date2:dd-MMM-yyyy}";
            lblMarka.Text = marka;
            lblSummary.Text = totalString;
            this.DataSource = data;
            endBalance=data.Sum(x=>x.Debit) - data.Sum(x => x.Credit);
            var sReport = new rptHeader(PartyId);
            sReport.CreateDocument();
            this.xrSubreport1.ReportSource = sReport;
        }

        private void xrTableCell3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell=sender as XRTableCell;
            if(cell.Value != null && cell.Value.ToString()==0.ToString())
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value != null && cell.Value.ToString() == 0.ToString())
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value != null && cell.Value.ToString() == 0.ToString())
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell15_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value != null && cell.Value.ToString() == 0.ToString())
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Value !=null && cell.Value.ToString() == 0.ToString())
            {
                cell.Text = string.Empty;
            }
        }

        private void xrTableCell13_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = Math.Abs(endBalance).ToString("0.##");
        }

        private void endSate_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (endBalance <= 0)
            {
                cell.Text = "جمع";
            }
            else
            {
                cell.Text = "بنام";
            }
        }
    }
}
