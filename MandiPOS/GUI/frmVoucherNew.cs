using MandiPOS.CLasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmVoucherNew : Form
    {
        int VoucherType = 0;
        clsResize resizer;
        private bool isLoading;
        Vouchers main = new Vouchers();
        public frmVoucherNew(int _voucherType)
        {
            InitializeComponent();
            txtCode.RegisterFocus(true);
            txtCashBank.RegisterFocus(true);
            txtAmount.RegisterFocus(false);
            txtNarration.RegisterFocus(true);
            txtName.RegisterFocus(true);
            dtp.RegisterFocus(false);
            dgvHelp.RowDoubleClick += DgvHelp_RowDoubleClick;
            this.KeyPreview = true;
            this.Load += FrmVoucherNew_Load;
            dgvHelp.KeyDown += DgvHelp_KeyDown;
            gridEX1.DoubleClick += GridEX1_DoubleClick;
            txtAmount.Enter += TxtAmount_Enter;
            dtp.KeyDown += Dtp_KeyDown;
            txtAmount.KeyDown += TxtAmount_KeyDown;
            txtName.KeyDown += TxtName_KeyDown;
            txtName.Enter += ((s, e) =>
            {
                Program.UrduInput(true);
            });
            this.Resize += FrmVoucherNew_Resize;
            txtCashBank.KeyDown += TxtCashBank_KeyDown;
            txtNarration.KeyDown += TxtNarration_KeyDown;
            resizer = new clsResize(this);
            VoucherType = _voucherType;
            switch (VoucherType)
            {
                case 0: this.Text = lblTitle.Text = "رقم بنام ووچر"; break;
                case 1: this.Text = lblTitle.Text = "رقم جمع ووچر"; break;
            }
        }

        private void GridEX1_DoubleClick(object sender, EventArgs e)
        {
            if (gridEX1.IsRow())
            {
                VoucherCart c = bsCart[gridEX1.CurrentRow.RowIndex] as VoucherCart;
                txtCode.Text = c.PartyCode.ToString();
                txtName.Text = c.PartyName.ToString();
                currentAccount = c.PartyID;
                SetPartybalance();
                txtCashBank.SelectedValue = c.CashAccountID;
                txtNarration.Text = c.Narration;
                txtAmount.Text = c.Amount.ToString("0.##");
                bsCart.RemoveAt(gridEX1.CurrentRow.RowIndex);
                bsCart.ResetBindings(false);
                txtName.Select();
            }
        }

        private void DgvHelp_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {

        }

        private void DgvHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvHelp.Visible = false;
                txtName.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvHelp.CurrentRow != null && dgvHelp.CurrentRow.RowIndex != -1 && dgvHelp.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    DataRow[] row = dtParties.Select($"ID='{dgvHelp.GetValue(0)}'");
                    if (row.Length > 0)
                    {

                        txtCode.Text = row[0]["AccountCode"].ToString();
                        txtName.Text = row[0]["AccountTitle"].ToString();
                        currentAccount = row[0]["ID"].toInt();
                        SetPartybalance();
                        dgvHelp.Visible = false;
                        e.SuppressKeyPress = true;
                        txtName.Select();
                    }
                }
            }
        }
        int currentAccount;
        DataTable dtParties = new DataTable();
        public override void Refresh()
        {
            try
            {
                if (dtp.Value == null || dtp.Value.Date <= DateTime.MinValue.Date)
                {
                    return;
                }
                if (dtp.Value.Date < DateTime.Now.Date && !General.IsAdmin)
                {
                    this.Info("آپکو پرانا ووچر دیکھنے کی اجازت نہیں ہے۔");
                    dtp.Value = DateTime.Now.Date;
                    return;
                }
                if (dtp.Value.Date < DateTime.Now.Date)
                {
                    if (this.Ask("کیا آپ یہ ووچر کھولنا چاہتےہین؟") == false)
                    {
                        return;
                    }
                }
                isLoading = true;
                main = VoucherService.GetVoucher(VoucherType, dtp.Value.Date);
                bsCart.DataSource = main.Entries;
                bsCashBank.DataSource = DetailAccountService.BankCashAccounts();
                dtParties = DetailAccountService.PartyAccounts().ToDataTable();
                bsParties.DataSource = dtParties;
                txtCashBank.SelectedIndex = 0;
                isLoading = false;
                txtName.Select();
            }
            catch (Exception ex)
            {
                ex.ExcError("While Loading Voucher...");
            }
        }
        private void Dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Refresh();
            }
        }

        private void TxtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToCart();
            }
        }
        bool isChanged = false;
        private void AddToCart()
        {
            if (txtCode.Text.Trim() == string.Empty || txtName.Text.Trim() == string.Empty || currentAccount == 0)
            {
                this.Error("پارٹی اکاؤنٹ منتخب کریں۔");
                txtName.Select();
                return;
            }
            if (txtCashBank.SelectedIndex == -1 || txtCashBank.SelectedValue == null)
            {
                this.Error("کیش / بینک اکاؤنٹ منتخب کریں۔");
                txtCashBank.Select();
                return;
            }
            if (txtAmount.Text.Trim().toDecimal() == 0)
            {
                this.Error("رقم کا اندراج کریں۔");
                txtAmount.Select();
                return;
            }
            VoucherCart c = new VoucherCart()
            {
                Amount = txtAmount.Text.toDecimal(),
                CashAccount = txtCashBank.Text,
                CashAccountID = txtCashBank.SelectedValue.toInt(),
                EntryID = 0,
                Narration = txtNarration.Text.Trim(),
                PartyCode = txtCode.Text.Trim(),
                PartyID = currentAccount,
                PartyName = txtName.Text.Trim()
            };
            bsCart.Add(c);
            bsCart.ResetBindings(false);
            isChanged = true;
            ClearControls();
            txtName.Select();
        }

        private void ClearControls()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCashBank.SelectedIndex = 0;
            txtName.Clear();
            txtAmount.Text = 0.ToString("0.##");
        }

        private void TxtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Select();
            }
        }

        private void TxtCashBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNarration.Select();
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCashBank.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                dgvHelp.Select();
            }
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.SelectAll();
        }

        private void FrmVoucherNew_Resize(object sender, EventArgs e)
        {
            resizer._resize();
        }

        private void FrmVoucherNew_Load(object sender, EventArgs e)
        {
            resizer._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
            dtp.Value = DateTime.Now;
            Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused && txtName.Text.Length > 0)
            {
                dgvHelp.Visible = true;
                bsParties.Filter = $"AccountTitle Like '%{txtName.Text}%'";
            }
            else if (txtName.Focused && txtName.Text.Length == 0)
            {
                dgvHelp.Visible = false;
                bsParties.RemoveFilter();
            }
            currentAccount = 0;
            SetPartybalance();
        }
        void SetPartybalance()
        {
            if (currentAccount != 0)
            {
                partyBal.Text = this.GetPartyBalance(currentAccount);
                if (partyBal.Text.Trim().toDecimal() > 0)
                {
                    partyBal.ForeColor = Color.Red;
                }
                else if (partyBal.Text.Trim().toDecimal() < 0)
                {
                    partyBal.ForeColor = Color.ForestGreen;
                }
                else
                {
                    partyBal.ForeColor = Color.Black;
                }
            }
            else
            {
                partyBal.Text = string.Empty;
            }
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (dtp.Value.Date < DateTime.Now.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر محفوظ کرنے کی اجازت نہیں ہے۔");
                return;
            }
            if (bsCart.Count == 0)
            {
                this.Error("کم از کم ایک اندراج ضروری ہے۔");
                return;
            }
            if (dtp.Value.Date < DateTime.Now.Date)
            {
                if (this.Ask("کیا آپ یہ پُرانا ووچر محفوظ کرنا چاہتے ہیں؟") == false)
                {
                    return;
                }
            }
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

        private void txtName_Leave(object sender, EventArgs e)
        {

        }
    }
}
