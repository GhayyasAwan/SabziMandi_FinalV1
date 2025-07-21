using DevExpress.XtraEditors;

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
    public partial class frmMasterAccounts : DevExpress.XtraEditors.XtraForm
    {
        MasterAccounts master;
        public frmMasterAccounts()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += FrmMasterAccounts_KeyDown;
            dgv.RowClick += Dgv_RowClick;
            dgv.KeyDown += Dgv_KeyDown;
            cmbType.KeyDown += CmbType_KeyDown;
            this.Load += FrmMasterAccounts_Load;
            txtTitle.KeyDown += TxtTitle_KeyDown;
        }

        private void TxtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv.Focus();
            }
        }

        private void FrmMasterAccounts_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void CmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                master.AccountTitle = txtTitle.Text.Trim();
                master.AccountType = cmbType.SelectedItem.ToString();
                if (string.IsNullOrEmpty(master.AccountTitle))
                {
                    this.Error("عنوان کھاتہ درج کریں");
                    txtTitle.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(master.AccountType))
                {
                    this.Error("قسم کھاتہ منتخب کریں");
                    cmbType.Focus();
                    return;
                }
                try
                {
                    if (MasterAccountsService.SaveMasterAccount(master))
                    {
                        this.Info("ریکارڈ محفوظ ہو گیا ہے۔");
                        Refresh();
                    }
                    else
                    {
                        this.Error("ریکارڈ محفوظ نہیں ہو سکا۔");
                    }
                }
                catch (Exception ex)
                {

                    ex.ExcError(" Saving Master Account... ");
                }
            }
        }

        private void FrmMasterAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Refresh();
            }
        }
        public override void Refresh()
        {
            master = new MasterAccounts();
            BIndObject();
            masterAccountsBindingSource.DataSource = MasterAccountsService.GetMasterAccounts();
            txtTitle.Select();
        }
        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgv.FocusedRowHandle >= 0)
            {
                EditCurrent();
            }
            if (e.KeyCode == Keys.Delete && dgv.FocusedRowHandle >= 0)
            {
                master = (MasterAccounts)dgv.GetFocusedRow();
                if (master != null)
                {
                    if (master.IsSystem)
                    {
                        this.Info("یہ کھاتہ ڈیلیٹ نہیں کیا جا سکتا۔");
                    }
                    else
                    {
                        try
                        {
                            MasterAccountsService.DeleteMasterAccount(master.ID);
                            Refresh();
                        }
                        catch (Exception exx)
                        {
                            exx.ExcError("While Deleting Master Account...");
                        }
                    }

                }
            }
        }

        private void EditCurrent()
        {
            master = (MasterAccounts)dgv.GetFocusedRow();
            if (master != null)
            {
                BIndObject();
            }
        }

        private void BIndObject()
        {
            txtTitle.Text = master.AccountTitle;
            cmbType.SelectedItem = master.AccountType;
            txtTitle.Select();
        }

        private void Dgv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dgv.FocusedRowHandle >= 0)
            {
                EditCurrent();
            }
        }
    }
}