using System;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmBardanaReport : Form
    {
        public frmBardanaReport()
        {
            InitializeComponent();
            dtp1.Value = dtp2.Value = DateTime.Now.Date;
            this.Load += FrmBardanaReport_Load;
        }

        private void FrmBardanaReport_Load(object sender, EventArgs e)
        {
            dgv.setReadOnly();
            tblItemsBindingSource.DataSource = SQL.GetBardanaItems();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (dtp1.Value.Date > dtp2.Value.Date)
            {
                this.Info("درست تاریخ کا انتخاب کریں");
                return;
            }
            if (cmbItems.SelectedIndex == -1 || cmbItems.SelectedValue.toInt() == 0)
            {
                this.Info("اشیاء کا انتخاب کریں");
                return;
            }
            bs.DataSource = SQL.GetBardanaLedger(dtp1.Value.Date, dtp2.Value.Date, cmbItems.SelectedValue.toInt());
        }
    }
}
