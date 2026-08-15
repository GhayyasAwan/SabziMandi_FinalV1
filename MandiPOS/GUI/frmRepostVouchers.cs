using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmRepostVouchers : Form
    {
        public frmRepostVouchers()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex != -1)
            {
                if (this.Ask("Are You Sure to Re-Post Voucher of Selected Type?"))
                {
                    try
                    {
                        Application.UseWaitCursor = true;
                        IEnumerable<Vouchers> list = VoucherService.GetList(uiComboBox1.SelectedValue.toInt());
                        uiProgressBar1.Value = 0;
                        uiProgressBar1.Maximum = list.Count();
                        foreach (Vouchers record in list)
                        {

                            var v = VoucherService.GetVoucherById( record.VoucherType.toInt(),record.VoucherID);
                            VoucherService.SaveVoucher(v);
                            uiProgressBar1.Value++;
                            Application.DoEvents();
                        }

                        Application.UseWaitCursor = false;
                        this.Info("Operation Complete.");
                    }
                    catch (Exception ex)
                    {
                        this.Error(ex.Message);
                    }
                }
            }
        }
    }
}
