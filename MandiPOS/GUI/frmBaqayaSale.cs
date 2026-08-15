using MandiPOS.CLasses;

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmBaqayaSale : Form
    {
        int partyID = 0;
        DateTime date1 = DateTime.Now;
        DateTime date2 = DateTime.Now;
        DataTable data = new DataTable();
        public frmBaqayaSale(List<BaqayaReportModel> records, int type)
        {
            InitializeComponent();
            lblParty.Text = type == 1 ? "بیوپاری گاہک سیل رپورٹ" : $"گاہک بقایا سیل رپورٹ";
            bs.DataSource = records;
            bs.ResetBindings(false);
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
