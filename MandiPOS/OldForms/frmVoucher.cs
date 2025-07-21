using DevExpress.XtraGrid.Views.Grid;

using MandiPOS.CLasses;

using System;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmVoucher : DevExpress.XtraEditors.XtraForm
    {
        int VoucherType = 0;
        GridView dgv;
        Vouchers main = new Vouchers();
        public frmVoucher(int vouchertype)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += FrmVoucher_FormClosing;
            dt.ValueChanged += Dt_EditValueChanged;
            dgv = gridView1 as GridView;
            main = new Vouchers();
            gridView1.ShownEditor += (s, e) =>
            {
                var view = s as DevExpress.XtraGrid.Views.Grid.GridView;

                // Optionally check the focused column if needed
                var column = view.FocusedColumn;
                if (column != null && column.FieldName == "Narration")
                {
                    Program.UrduInput(true);
                }
                else
                {
                    Program.UrduInput(false);
                }
            };
            dt.Value = DateTime.Now.Date;
            #region VoucherTypeSettings
            VoucherType = vouchertype;
            switch (VoucherType)
            {
                case 0: this.Text = "رقم بنام ووچر"; break;
                case 1: this.Text = "رقم جمع ووچر"; break;
            }
            #endregion
            this.Load += FrmVoucher_Load;
            cmbParty.EditValueChanged += CmbParty_EditValueChanged;
            txtCode.Enter += (s, e) => SwitchInputLanguage(s, e, true);
            cmbParty.Enter += (s, e) => SwitchInputLanguage(s, e, true);
            cmbCash.Enter += (s, e) => SwitchInputLanguage(s, e, true);
            txtnarration.Enter += (s, e) => SwitchInputLanguage(s, e, true);
            txtAmount.Enter += (s, e) => SwitchInputLanguage(s, e, false);
            txtCode.Leave += (s, e) => SwitchInputLanguage(s, e, false);
            cmbParty.Leave += (s, e) => SwitchInputLanguage(s, e, false);
            cmbCash.Leave += (s, e) => SwitchInputLanguage(s, e, false);
            txtnarration.Leave += (s, e) => SwitchInputLanguage(s, e, false);
            txtAmount.KeyDown += TxtAmount_KeyDown;



        }

        private void Dt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dt.Value == null || dt.Value.Date <= DateTime.MinValue.Date)
                {
                    return;
                }
                isLoading = true;
                main = VoucherService.GetVoucher(VoucherType, dt.Value.Date);
                bsCart.DataSource = main.Entries;
                isLoading = false;
                cmbParty.Select();
            }
            catch (Exception ex)
            {
                ex.ExcError("While Loading Voucher...");
            }
        }

        private void FrmVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged && !this.Ask("ووچر میں کی گئی تبدیلیاں محفوظ نہیں ہیں، کیا آپ واقعی فارم بند کرتا چاہتے ہیں؟"))
            {
                e.Cancel = true;
            }
        }

        private void CmbParty_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbParty.EditValue == null)
            {
                txtCode.Clear();
            }
            else
            {
                var acc = cmbParty.GetSelectedDataRow() as DetailAccountView;
                if (acc != null)
                {
                    txtCode.EditValue = acc.AccountCode;
                }
            }
        }

        private void TxtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToCart();
            }
        }

        private void AddToCart()
        {
            if (cmbParty.EditValue == null)
            {
                this.Error("پارٹی منتخب کریں");
                cmbParty.Select();
                cmbParty.ShowPopup();
                return;
            }
            if (cmbCash.EditValue == null)
            {
                this.Error("کیش اکاؤنٹ منتخب کریں");
                cmbCash.Select();
                cmbCash.ShowPopup();
                return;
            }
            if (txtAmount.EditValue.toDecimal() == 0)
            {
                this.Error("رقم درج کریں");
                return;
            }
            VoucherCart c = new VoucherCart()
            {
                Amount = txtAmount.EditValue.toDecimal(),
                CashAccountID = cmbCash.EditValue.toInt(),
                CashAccount = cmbCash.Text.Trim(),
                EntryID = 0,
                PartyCode = txtCode.Text.Trim(),
                Narration = txtnarration.Text.Trim(),
                PartyID = cmbParty.EditValue.toInt(),
                PartyName = cmbParty.Text.Trim()
            };
            bsCart.Add(c);
            bsCart.ResetBindings(false);
            ClearEntryPanel();
            if (!isLoading)
            {
                isChanged = true;
            }
            cmbParty.Select();
        }

        private void ClearEntryPanel()
        {
            txtCode.Clear();
            cmbParty.EditValue = (bsCashBank[0] as DetailAccountView).ID;
            cmbCash.EditValue = null;
            txtnarration.Clear();
            txtAmount.EditValue = 0;
        }

        bool isChanged = false;
        bool isLoading = false;
        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SwitchInputLanguage(object sender, EventArgs e, bool flag)
        {
            Program.UrduInput(flag);
        }



        private void FrmVoucher_Load(object sender, EventArgs e)
        {
            ClearControls();

        }

        private void ClearControls()
        {
            Refresh();
        }

        public override void Refresh()
        {
            bsCashBank.DataSource = DetailAccountService.BankCashAccounts();
            bsParties.DataSource = DetailAccountService.PartyAccounts();
            ClearEntryPanel();
        }

        private void EditCurrentRecord(object sender, EventArgs e)
        {
            if (dgv.FocusedRowHandle >= 0)
            {
                VoucherCart c = bsCart.Current as VoucherCart;
                if (c != null)
                {
                    cmbParty.EditValue = c.PartyID;
                    cmbCash.EditValue = c.CashAccountID;
                    txtnarration.EditValue = c.Narration;
                    txtAmount.EditValue = c.Amount;
                    bsCart.Remove(c);
                    bsCart.ResetBindings(false);
                    if (!isLoading)
                    {
                        isChanged = true;
                    }
                    cmbParty.Select();
                }
            }
        }

        private void RemoveCurrentRecord(object sender, EventArgs e)
        {
            if (dgv.FocusedRowHandle >= 0 && this.Ask("کیا آپ اس ریکارڈ کوختم کرنا چاہتے ہیں؟"))
            {
                bsCart.RemoveAt(dgv.FocusedRowHandle);
                bsCart.ResetBindings(false); if (!isLoading)
                {
                    isChanged = true;
                }
            }
        }

        private void SaveRecord(object sender, EventArgs e)
        {
            dgv.ValidateEditor();
            try
            {
                VoucherService.SaveVoucher(main);
                //finally
                isChanged = false;
                this.Info("ریکارڈ محفوظ ہو گیا ہے۔");
            }
            catch (Exception ex)
            {
                ex.ExcError("While Saving Voucher...");
            }
        }

        private void cmbParty_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }
    }
}