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
    public partial class frmDateChanger : Form
    {
        private int vType = 0;
        private int VID = 0;
        private DateTime currentDate = new DateTime();
        public frmDateChanger(int vType, int vID, DateTime currentDate)
        {
            InitializeComponent();
            this.Text = "Date Changer";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = this.MaximizeBox = false;
            this.ShowInTaskbar = false;

            this.vType = vType;
            VID = vID;
            this.currentDate = currentDate;
        }

        private void calendarCombo2_ValueChanged(object sender, EventArgs e)
        {
            if (calendarCombo1.Value.Date == calendarCombo2.Value.Date)
            {
                uiButton1.Enabled = false;
            }
            else
            {
                bool IsAlreadyAssigned =SQL.IsDateAssigned(calendarCombo2.Value.Date, vType);
                uiButton1.Enabled = !IsAlreadyAssigned;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SQL.ChangeVoucherDate(VID, calendarCombo2.Value.Date);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.Error(ex.Message);
            }
        }
    }
}
