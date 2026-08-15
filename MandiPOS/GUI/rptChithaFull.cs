using MandiPOS.Reports;

using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace MandiPOS.GUI
{
    public partial class rptChithaFull : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtAll;
        DataTable _dtActive;
        DataTable _dtInActive;
        int SortOrder = 0;
        bool ShowZero = false;
        bool showInacive = false;
        bool SummaryOnly = false;
        public rptChithaFull(DataTable dt = null, string date = "", int sortOrder = 0, int reportType = 1, string title = "چٹھہ مکمل", DataTable dt2 = null)
        {
            InitializeComponent();
            this.HideWarnings();
            lblTitle.Text = title;
            ShowZero = reportType == 2;
            showInacive = true;
            SummaryOnly = reportType == 3;
            lblDate.Text = date;

            _dtActive = dt;
            var rows = dt.Select("MasterID=11 and MasterID=12");
            _dtInActive = dt2;
            SortOrder = sortOrder;
            GetJamaRecords();
            GetBanamRecords();
            GetJamaRecords_InActive();
            GetBanamRecords_InActive();
            if (!showInacive)
            {
                SubBand3.Visible = SubBand4.Visible = SubBand5.Visible = false;
                SubBand3.Controls.Clear();
                SubBand3.HeightF = 0;
                SubBand4.Controls.Clear();
                SubBand4.HeightF = 0;
                SubBand5.Controls.Clear();
                SubBand5.HeightF = 0;
            }
            //xrSubreport2.BeforePrint += XrSubreport2_BeforePrint;
            //xrSubreport1.BeforePrint += XrSubreport1_BeforePrint;

        }

        decimal banam = 0;
        decimal jama = 0;
        decimal banamIA = 0;
        decimal jamaIA = 0;
        void GetTotals()
        {
            if (_dtActive != null)
            {
                banam = _dtActive.Compute("SUM(EndBalance)", "EndBalance > 0").toDecimal();
                jama = _dtActive.Compute("SUM(EndBalance)", "EndBalance < 0").toDecimal();
            }
            if (_dtInActive != null)
            {
                banamIA = _dtInActive.Compute("SUM(EndBalance)", "EndBalance > 0").toDecimal();
                jamaIA = _dtInActive.Compute("SUM(EndBalance)", "EndBalance < 0").toDecimal();
            }
            lblBanam.Text = (banam + banamIA).ToString("N0");
            lblJama.Text = Math.Abs(jama + jamaIA).ToString("N0");
            decimal diff = banam + banamIA + jamaIA + jama;
            lbldiff1.Text = $"{Math.Abs((diff)).ToString("N0")} {(diff < 0 ? "جمع" : "بنام")}";
            lblRokar.Text = $"{Math.Abs((diff)).ToString("N0")} {(diff > 0 ? "جمع" : "بنام")}";
            lblEnd.Text = "0";

        }
        private void XrSubreport2_BeforePrint(object sender, CancelEventArgs e)
        {
            GetJamaRecords();

        }
        private void GetJamaRecords_InActive()
        {
            string filter = "EndBalance<0";
            var rows = _dtInActive.Select(filter);
            if (SortOrder == 0)
            {
                rows.OrderBy(r => r["ID"]);
            }
            else
            {
                rows.OrderBy(r => r["OldAccountCode"]);
            }
            if (rows.Length > 0)
            {

                var subReport = new rptChithaRecords("جمع", SortOrder, SummaryOnly);
                subReport.DataSource = rows.CopyToDataTable();

                subReport.CreateDocument();
                xrSubreport3.ReportSource = subReport;

            }
            else
            {
                SubBand4.Controls.Clear();
                SubBand4.HeightF = 0;
            }
            GetTotals();
        }
        private void GetJamaRecords()
        {
            string filter = "EndBalance<0";
            var rows = _dtActive.Select(filter);
            if (SortOrder == 0)
            {
                rows.OrderBy(r => r["ID"]);
            }
            else
            {
                rows.OrderBy(r => r["OldAccountCode"]);
            }
            if (rows.Length > 0)
            {
                var subReport = new rptChithaRecords("جمع", SortOrder, SummaryOnly);
                subReport.DataSource = rows.CopyToDataTable();

                subReport.CreateDocument();
                xrSubreport1.ReportSource = subReport;

            }
            else
            {
                SubBand1.Controls.Clear();
                SubBand1.HeightF = 0;
            }
            GetTotals();
        }

        private void XrSubreport1_BeforePrint(object sender, CancelEventArgs e)
        {
            GetBanamRecords();
        }

        private void GetBanamRecords()
        {
            string filter = ShowZero ? "EndBalance >= 0" : "EndBalance > 0";
            var rows = _dtActive.Select(filter);
            if (SortOrder == 0)
            {
                rows.OrderBy(r => r["ID"]);
            }
            else
            {
                rows.OrderBy(r => r["OldAccountCode"]);
            }
            if (rows.Length > 0)
            {
                var subReport = new rptChithaRecords("بنام", summary: SummaryOnly);
                subReport.DataSource = rows.CopyToDataTable();
                subReport.CreateDocument();
                xrSubreport2.ReportSource = subReport;
            }
            else
            {
                SubBand2.Controls.Clear();
                SubBand2.HeightF = 0;
            }
            GetTotals();
        }
        private void GetBanamRecords_InActive()
        {
            string filter = (ShowZero ? "EndBalance>=0" : "EndBalance>0");
            var rows = _dtInActive.Select("EndBalance > 0");
            if (SortOrder == 0)
            {
                rows.OrderBy(r => r["ID"]);
            }
            else
            {
                rows.OrderBy(r => r["OldAccountCode"]);
            }
            if (rows.Length > 0)
            {
                var subReport = new rptChithaRecords("بنام", summary: SummaryOnly);
                subReport.DataSource = rows.CopyToDataTable();
                subReport.CreateDocument();
                xrSubreport4.ReportSource = subReport;
            }
            else
            {
                SubBand5.Controls.Clear();
                SubBand5.HeightF = 0;
            }
            GetTotals();
        }
    }
}
namespace MandiPOS.CLasses
{
    public class chithaReport
    {
        public int ID { get; set; }
        public string AccountTitle { get; set; }
        public string MasterAccount { get; set; }
        public string refName { get; set; }
        public string Contact { get; set; }
        public string CityName { get; set; }
        public decimal EndBalance { get; set; }
        public int OldAccountCode { get; set; }
    }
}
