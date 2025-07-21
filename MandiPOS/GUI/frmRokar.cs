using DevExpress.XtraReports.UI;
using MandiPOS.Reports;
using System.ComponentModel;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmRokar : Form
    {
        public frmRokar()
        {
            InitializeComponent();
            dtp.RegisterFocus(false);
            dtp.KeyDown += ((s, e) => { dtp.EnterToNext(e); });
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            var report = new rptRokar(dtp.Value.Date);
            report.ShowPreview();
        }
    }
}
namespace MandiPOS.CLasses
{
    public class RokarEntries
    {
        [DisplayName("عنوان کھاتہ")]
        public string AccountTitle { get; set; }
        [DisplayName("تفصیل")]
        public string Narration { get; set; }
        [DisplayName("انٹری نمبر")]
        public string EntryID { get; set; }
        [DisplayName("رقم")]
        public decimal Amount { get; set; }
    }
}
