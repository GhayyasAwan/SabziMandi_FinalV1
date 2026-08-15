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
    public partial class frmSecurityPasswords : Form
    {
        public frmSecurityPasswords()
        {
            InitializeComponent();
            p1.RegisterFocus();
            p2.RegisterFocus();
            p3.RegisterFocus();
            p1.EnterToNext();
            p2.EnterToNext();
            p3.EnterToNext();
            this.Load += FrmSecurityPasswords_Load;
        }
        tblSecurity sec = new tblSecurity();
        private void FrmSecurityPasswords_Load(object sender, EventArgs e)
        {
            refreshRecord();
        }

        private void refreshRecord()
        {
            sec = tblSecurity.Get;
            if (sec == null)
                sec = new tblSecurity();
            p1.Text = sec.P1.Decrypt();
            p2.Text = sec.P2.Decrypt();
            p3.Text = sec.P3.Decrypt();
            p1.Select(); p1.SelectAll();
        }

        private void frmSecurityPasswords_Load(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            sec.P1 = p1.Text.Encrypt();
            sec.P2 = p2.Text.Encrypt();
            sec.P3 = p3.Text.Encrypt();
            try
            {
                tblSecurity.Save(sec);
                refreshRecord();
                this.Info("ڈیٹا محفوظ ہو گیا۔");
            }
            catch (Exception ex)
            {
                ex.ExcError();
            }
        }
    }
}
