using DevExpress.XtraReports.UI;

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace MandiPOS.Reports
{
    public partial class MarkaReportDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public MarkaReportDetail(object  data, int partyID)
        {
            InitializeComponent();
            var rpt = new rptHeader(partyID);
            rpt.CreateDocument();
            xrSubreport1.ReportSource = rpt;
            this.DataSource = data;
        }
    }
}
