using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace MandiPOS.Reports
{
    public partial class rptJVPrint : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJVPrint(List<JVCart> data,string title,string vno, string date)
        {
            InitializeComponent();
            lblVoucherTitle.Text = title;
            lblVoucherDate.Text = date;
            lblVoucherNo.Text = vno;
            this.DataSource = data;
            this.CreateDocument();
        }

    }
}
