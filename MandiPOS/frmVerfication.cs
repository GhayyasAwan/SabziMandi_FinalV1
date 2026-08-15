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

namespace MandiPOS
{
    public partial class frmVerfication : Form
    {
        int VerficationID;
        tblSecurity sec = new tblSecurity();
        public frmVerfication(int VerificationType)
        {
            InitializeComponent();
            VerficationID = VerificationType;
            txtPin.RegisterFocus(false);
            txtPin.KeyDown += TxtPin_KeyDown;
        }

        private void TxtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtPin.Text.Trim()))
            {
                VerifyCode();
            }
        }

        private void VerifyCode()
        {
            sec = tblSecurity.Get;
            bool result = false;
            switch (VerficationID)
            {
                case 1: result = sec.P1.Decrypt() == txtPin.Text.Trim(); break;
                case 2: result = sec.P2.Decrypt() == txtPin.Text.Trim(); break;
                case 3: result = sec.P3.Decrypt() == txtPin.Text.Trim(); break;
            }
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Error("پن کوڈ درست نہیں۔");
                return;
            }
        }
    }
}
