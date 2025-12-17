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
        public rptChithaFull(DataTable dt = null, string date = "", int sortOrder = 0, bool _showZero = false, bool _showInacive = false, bool _summaryOnly = false)
        {
            InitializeComponent();
            ShowZero = _showZero;
            showInacive = _showInacive;
            SummaryOnly = _summaryOnly;
            lblDate.Text = date;
            _dtAll = dt;
            _dtActive=dt.Select("IsActive=1").CopyToDataTable();
            var rows = dt.Select("IsActive=0");
            _dtInActive = rows.Length > 0 ? rows.CopyToDataTable() : dt.Clone();
            SortOrder = sortOrder;
            GetJamaRecords();
            GetBanamRecords();
            GetJamaRecords_InActive();
            GetBanamRecords_InActive();
            if (!showInacive)
            {
                SubBand3.Visible = SubBand4.Visible = SubBand5.Visible=false;
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
        void GetTotals()
        {
            if (_dtAll != null)
            {
                banam = _dtAll.Compute("SUM(EndBalance)", "EndBalance > 0").toDecimal();
                jama = _dtAll.Compute("SUM(EndBalance)", "EndBalance < 0").toDecimal();
            }
            lblBanam.Text = banam.ToString("N0");
            lblJama.Text = Math.Abs(jama).ToString("N0");
            lblDiff.Text = (banam + jama).ToString("N0");
        }
        private void XrSubreport2_BeforePrint(object sender, CancelEventArgs e)
        {
            GetJamaRecords();

        }
        private void GetJamaRecords_InActive()
        {
            string filter = (ShowZero ? "EndBalance<=0" : "EndBalance<0");
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
            string filter = (ShowZero ? "EndBalance<=0" : "EndBalance<0");
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

            var rows = _dtActive.Select("EndBalance > 0");
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
                var subReport = new rptChithaRecords("بنام",summary: SummaryOnly);
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
