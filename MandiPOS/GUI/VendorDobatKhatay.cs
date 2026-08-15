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
    public partial class VendorDobatKhatay : Form
    {
        public VendorDobatKhatay()
        {
            InitializeComponent();
            this.Load += CustomerDobatKhatay_Load;
            dgvCustomer.RowDoubleClick += DgvCustomer_RowDoubleClick;
            dgvCustomerDobat.RowDoubleClick += DgvCustomerDobat_RowDoubleClick;
        }

        private void CustomerDobatKhatay_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void DgvCustomerDobat_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgvCustomerDobat.IsRow() && this.Ask("کیا آپ واقعی اس کھاتہ کو شفٹ کرنا چاہتے ہیں؟"))
            {
                if (SQL.ShiftAccount(dgvCustomerDobat.RecordID(), 11, 4, true))
                {
                    Refresh();
                }
            }
        }

        public override void Refresh()
        {
            bsCustomers.DataSource = DetailAccountService.GetAccountsViewList(4, true);
            bsDobatCustomers.DataSource = DetailAccountService.GetAccountsViewList(11, true);
            bsCustomers.ResetBindings(false);
            bsDobatCustomers.ResetBindings(false);
        }
        private void DgvCustomer_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgvCustomer.IsRow() && this.Ask("کیا آپ واقعی اس کھاتہ کو شفٹ کرنا چاہتے ہیں؟"))
            {
                if (SQL.ShiftAccount(dgvCustomer.RecordID(), 4, 11, false))
                {
                    Refresh();
                }
            }
        }
    }
}
