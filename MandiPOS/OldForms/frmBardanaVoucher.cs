using Janus.Windows.GridEX;

using MandiPOS.CLasses;

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmBardanaVoucher : Form
    {
        Vouchers main = new Vouchers();
        int vType = 3;
        public frmBardanaVoucher()
        {
            InitializeComponent();
            this.FormClosing += FrmBardanaVoucher_FormClosing;
            this.Load += FrmBardanaVoucher_Load;
            clearEntryPanel();
            txtQty.Enter += (s, e) => { Program.UrduInput(false); };
            txtRate.Enter += (s, e) => { Program.UrduInput(false); };
            cmbItems.Enter += (s, e) => { Program.UrduInput(true); };
            cmbParties.Enter += (s, e) => { Program.UrduInput(true); };
            txtNarration.Enter += (s, e) => { Program.UrduInput(true); };
            gridEX1.SetColumnsFormat(true, new string[] { "ItemQty", "DebitAmount", "CreditAmount" }, new string[] { "Code" });
            rbSeeds.CheckedChanged += GetItems;
            rbBardana.CheckedChanged += GetItems;
            cmbParties.EditValueChanged += CmbParties_EditValueChanged;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            txtRate.EditValueChanged += CalculateAmount;
            txtQty.EditValueChanged += CalculateAmount;
            txtRate.KeyDown += RateKeyDown;
            dateTimePicker1.KeyDown += DateTimePicker1_KeyDown;
            gridEX1.FormattingRow += GridEX1_FormattingRow;
            dateTimePicker1.Value = DateTime.Now.Date;
        }
        /// <summary>
        /// Check If Any Changes Before Closing Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBardanaVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged && !this.Ask("ووچر میں کی گئی تبدیلیاں محفوظ نہیں ہیں، کیا آپ واقعی فارم بند کرتا چاہتے ہیں؟"))
            {
                e.Cancel = true;
            }
        }

        private void FrmBardanaVoucher_Load(object sender, EventArgs e)
        {

        }

        private void GridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.TotalRow)
            {
                decimal totalDebit = 0;
                decimal totalCredit = 0;

                if (decimal.TryParse(Convert.ToString(e.Row.Cells["DebitAmount"]?.Value), out decimal debit))
                    totalDebit = debit;

                if (decimal.TryParse(Convert.ToString(e.Row.Cells["CreditAmount"]?.Value), out decimal credit))
                    totalCredit = credit;

                decimal difference = totalDebit - totalCredit;

                // Only apply logic if the "ItemRate" column exists and is not null
                if (e.Row.Cells["ItemRate"] != null)
                {
                    e.Row.Cells["ItemRate"].Text = difference.ToString("0.##");

                    if (difference != 0)
                    {
                        e.Row.Cells["ItemRate"].FormatStyle = new GridEXFormatStyle
                        {
                            BackColor = Color.LightCoral,
                            ForeColor = Color.White,
                            FontBold = TriState.True
                        };
                    }
                    else
                    {
                        e.Row.Cells["ItemRate"].FormatStyle = new GridEXFormatStyle
                        {
                            BackColor = SystemColors.Info,
                            ForeColor = Color.Black,
                            FontBold = TriState.False
                        };
                    }
                }
            }
        }



        private void DateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetVoucher();
            }
        }

        private void RateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbItems.EditValue == null)
                {
                    this.Error("براہ کرم اشیاء منتخب کریں");
                    cmbItems.Select();
                    e.SuppressKeyPress = true; // Prevents the beep sound
                    return;
                }
                if (cmbParties.EditValue == null)
                {
                    this.Error("براہ کرم پارٹی منتخب کریں");
                    cmbParties.Select();
                    e.SuppressKeyPress = true; // Prevents the beep sound
                    return;
                }
                if (txtQty.EditValue.toDecimal() * txtRate.EditValue.toDecimal() == 0)
                {
                    this.Error("براہ کرم تعداد اور ریٹ درج کریں");
                    txtQty.Select();
                    e.SuppressKeyPress = true; // Prevents the beep sound
                    return;
                }
                else
                {
                    CalculateAmount(sender, e);
                    AddToCart();
                }
            }
        }
        private void AddToCart()
        {
            BardanaCart c = new BardanaCart()
            {
                AccountID = cmbParties.ItemIndex >= 0 ? (cmbParties.GetSelectedDataRow() as DetailAccountView).ID : 0,
                Code = txtCode.Text,
                CreditAmount = txtCredit.EditValue.toDecimal(),
                DebitAmount = txtDebit.EditValue.toDecimal(),
                ItemID = cmbItems.ItemIndex >= 0 ? (cmbItems.GetSelectedDataRow() as tblItems).ID : 0,
                ItemName = cmbItems.ItemIndex >= 0 ? (cmbItems.GetSelectedDataRow() as tblItems).ItemTitle : "",
                ItemQty = txtQty.EditValue.toDecimal(),
                ItemRate = txtRate.EditValue.toDecimal(),
                PartyName = cmbParties.ItemIndex >= 0 ? (cmbParties.GetSelectedDataRow() as DetailAccountView).AccountTitle : "",
                Narration = txtNarration.Text.Trim(),
                ID = 0,
                VoucherID = main.VoucherID
            };
            bsCart.Add(c); isChanged = true;
            bsCart.ResetBindings(false);
            clearEntryPanel();
            cmbParties.Select();
        }

        private void CalculateAmount(object sender, EventArgs e)
        {
            bool isDebit = rbBanam.Checked;
            if (isDebit)
            {
                txtCredit.Clear();
                txtDebit.Clear();
                decimal qty, rate;
                if (decimal.TryParse(txtQty.Text, out qty) && decimal.TryParse(txtRate.Text, out rate))
                {
                    txtDebit.EditValue = qty * rate;
                }
                else
                {
                    txtDebit.Clear();
                }
            }
            else
            {
                txtDebit.Clear();
                txtCredit.Clear();
                decimal qty, rate;
                if (decimal.TryParse(txtQty.Text, out qty) && decimal.TryParse(txtRate.Text, out rate))
                {
                    txtCredit.EditValue = qty * rate;
                }
                else
                {
                    txtCredit.Clear();
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetVoucher();
        }

        private void GetVoucher()
        {

        }

        private void CmbParties_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbParties.EditValue != null)
            {
                var acc = cmbParties.ItemIndex >= 0 ? cmbParties.GetSelectedDataRow() as DetailAccountView : null;
                if (acc != null) { txtCode.EditValue = acc.AccountCode; }
                else
                {
                    txtCode.Clear();
                }
            }
            else
            {
                txtCode.Clear();
            }
        }

        private void GetItems(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void clearEntryPanel()
        {
            txtCode.Clear();
            cmbParties.EditValue = null;
            txtCredit.Clear();
            txtDebit.Clear();
            txtNarration.Clear();
            cmbItems.EditValue = null;
            txtQty.Clear();
            txtRate.Clear();
            RefreshItems();
            RefreshParties();
        }

        private void RefreshParties()
        {
            bsParties.DataSource = DetailAccountService.PartyAccounts();
        }

        private void RefreshItems()
        {
            string itemtypes = "";
            if (rbSeeds.Checked)
            {
                itemtypes = "N'فروٹ',N'سبزی'"; // Fruits and Vegetables
            }
            else
            {
                itemtypes = "N'دیگر اشیاء'"; // Other Items
            }
            bsItems.DataSource = ItemService.GetItems(itemtypes);
        }

        private void CheckNumeric(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a control key (like backspace)
            if (char.IsControl(e.KeyChar))
            {
                return; // Allow control keys
            }

            // Check if the key pressed is a digit
            if (char.IsDigit(e.KeyChar))
            {
                return; // Allow digits
            }

            // Check if the key pressed is a decimal point
            if (e.KeyChar == '.')
            {
                // Check if the text already contains a decimal point
                TextBox textBox = sender as TextBox;
                if (textBox != null && textBox.Text.Contains('.'))
                {
                    e.Handled = true; // Prevent additional decimal points
                }
                return; // Allow the decimal point
            }

            // If the character is not a digit or a decimal point, suppress the key press
            e.Handled = true;
        }
        bool isChanged = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bsCart.Count == 0)
            {
                this.Error("براہ کرم کم از کم ایک اندراج شامل کریں");
                return;
            }
            var carts = bsCart.Cast<BardanaCart>();

            decimal totalDebit = carts.Sum(c => c.DebitAmount);
            decimal totalCredit = carts.Sum(c => c.CreditAmount);

            if (totalDebit != totalCredit)
            {
                this.Error("رقم بنام اور رقم جمع میں فرق ہے۔ براہ کرم درست کریں");
                return;
            }
            gridEX1.Validate();
            try
            {
                VoucherService.SaveVoucher(main);
                //finally
                isChanged = false;
                this.Info("ریکارڈ محفوظ ہو گیا ہے۔");
                dateTimePicker1.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                ex.ExcError("While Saving Voucher...");
            }
        }
    }
}
