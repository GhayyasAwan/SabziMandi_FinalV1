using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace MandiPOS.Reports
{
    public partial class rpt_BardanaReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BardanaReport(string PartyTitle, List<usp_GetBardanaReport> records)
        {
            InitializeComponent();
            lblPartyTitle.Text = PartyTitle;
            this.DataSource= records;
            
        }

    }
}
