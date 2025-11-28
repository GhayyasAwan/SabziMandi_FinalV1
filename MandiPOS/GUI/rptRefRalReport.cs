using MandiPOS.Reports;
using System;
using System.ComponentModel;
using System.Data;

namespace MandiPOS.GUI
{
    public partial class rptRefRalReport : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dt;
        public rptRefRalReport(DataTable dt = null, string date = "")
        {
            InitializeComponent();
            lblDate.Text = date;
            _dt = dt;
            GetJamaRecords();
            GetBanamRecords();

            //xrSubreport2.BeforePrint += XrSubreport2_BeforePrint;
            //xrSubreport1.BeforePrint += XrSubreport1_BeforePrint;

        }

        decimal banam = 0;
        decimal jama = 0;
        void GetTotals()
        {
            if (_dt != null)
            {
                banam = _dt.Compute("SUM(EndBalance)", "EndBalance > 0").toDecimal();
                jama = _dt.Compute("SUM(EndBalance)", "EndBalance < 0").toDecimal();
            }
            lblBanam.Text = banam.ToString("N0");
            lblJama.Text = Math.Abs(jama).ToString("N0");
            //lblDiff.Text = (banam + jama).ToString("N0");
        }
        private void XrSubreport2_BeforePrint(object sender, CancelEventArgs e)
        {
            GetJamaRecords();

        }

        private void GetJamaRecords()
        {
            var rows = _dt.Select("EndBalance < 0");
            if (rows.Length > 0)
            {
                var subReport = new rptChithaRecords("جمع");
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
            var rows = _dt.Select("EndBalance > 0");
            if (rows.Length > 0)
            {
                var subReport = new rptChithaRecords("بنام");
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
    }
}

