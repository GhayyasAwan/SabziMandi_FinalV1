using DevExpress.XtraReports.UI;

namespace MandiPOS.Reports
{
    public partial class rokarDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public rokarDetails(string _type = "")
        {
            InitializeComponent();
           // lblAccount.Text = $"{_type} کھاتہ";
           // lblAccount.Text = $"{_type} رقم";
        }

        private void xrTableCell5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null && cell.Value != null && cell.Value.ToString() == "0")
            {
                cell.Text = string.Empty; // Use Text instead of Value if you want to display blank
            }
        }
    }
}
