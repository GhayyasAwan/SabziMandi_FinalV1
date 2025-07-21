using Janus.Windows.GridEX;
using MandiPOS.CLasses;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmBVNew : Form
    {
        clsResize obj;
        Vouchers main = new Vouchers();
        int vType = 3;
        bool isChanged = false;

        public frmBVNew()
        {
            InitializeComponent();
            _narration.KeyDown += _narration_KeyDown;
            _qty.KeyDown += ((s, e) =>
            {
                if (e.EnterKey())
                {
                    _rate.Select();
                    _rate.SelectAll();
                }
            });

            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            _name.RightToLeft = _narration.RightToLeft = RightToLeft.Yes;
            _name.TextChanged += _name_TextChanged;
            dgvHelp.KeyDown += DgvHelp_KeyDown;
            dgv.FormattingRow += Dgv_FormattingRow;
            _name.KeyDown += _name_KeyDown;
            _qty.Enter += (s, e) => { Program.UrduInput(false); };
            _rate.Enter += (s, e) => { Program.UrduInput(false); };
            _items.Enter += (s, e) => { Program.UrduInput(true); };
            _name.Enter += (s, e) => { Program.UrduInput(true); };
            _narration.Enter += (s, e) => { Program.UrduInput(true); };
            rbSeed.CheckedChanged += GetItems;
            rbOther.CheckedChanged += GetItems;
            this.FormClosing += FrmBVNew_FormClosing;
            clearEntryPanel();
            this.Text = "بیج باردانہ ووچر";
            obj = new clsResize(this);
            this.Load += FrmBVNew_Load;
            this.Resize += FrmBVNew_Resize;
            _rate.TextChanged += CalculateAmount;
            _qty.TextChanged += CalculateAmount;
            _rate.KeyDown += RateKeyDown;
            dtp.KeyDown += Dtp_KeyDown;
            _items.KeyDown += (s, e) =>
            {
                if (e.EnterKey())
                {
                    _qty.Select();
                    _qty.SelectAll();
                }
            };
        }
        void SetPartybalance()
        {
            if (current != 0)
            {
                partyBal.Text = this.GetPartyBalance(current);
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
        private void Dgv_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
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

        private void _narration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _items.Select();
            }

        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv.IsRow())
            {
                var data = dgv.CurrentRow.DataRow as BardanaCart;
                if (data != null)
                {
                    if (data.DebitAmount != 0)
                    {
                        rbDebit.Checked = true;
                    }
                    else
                    {
                        tbCredit.Checked = true;
                    }
                    var item = SQL.GetAllItems($"Where ID='{data.ItemID}'").FirstOrDefault();
                    if (item != null)
                    {
                        if (item.ItemType == "دیگر اشیاء")
                        {
                            rbOther.Checked = true;
                        }
                        else
                        {
                            rbSeed.Checked = true;
                        }
                    }
                    _code.Text = data.Code;
                    _name.Text = data.PartyName;
                    current = data.AccountID;
                    SetPartybalance();
                    _narration.Text = data.Narration;
                    _items.SelectedValue = data.ItemID;
                    _qty.Value = data.ItemQty;
                    _rate.Value = data.ItemRate;
                    bsCart.Remove(data);
                    bsCart.ResetBindings(false);
                    _name.Select();
                    _name.SelectAll(); this.SwitchToUrdu();

                }
            }
        }

        private void _name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _narration.Select();
                _narration.SelectAll();
            }
            if (e.DownKey())
            {
                dgvHelp.Select();
            }
        }

        private void DgvHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey() && dgvHelp.IsRow())
            {
                var o = dgvHelp.RecordID(0);
                var data = dtParties.Select($"ID='{o}'");
                if (data.Length > 0)
                {
                    var row = data[0];
                    _code.Text = row["AccountCode"].ToString();
                    _name.Text = row["AccountTitle"].ToString();
                    current = row["ID"].ToString().toInt();
                    SetPartybalance();
                    dgvHelp.Hide();
                    _name.Select(); this.SwitchToUrdu();
                }
            }
            if (e.EscapeKey())
            {
                dgvHelp.Hide();
            }
        }

        private void _name_TextChanged(object sender, EventArgs e)
        {
            if (_name.Focused)
            {
                if (_name.Text.Length > 0)
                {
                    dgvHelp.Show();
                    bsParties.Filter = $"AccountTitle Like '%{_name.Text.Trim()}%'";
                    bsParties.ResetBindings(false);
                }
                else
                {
                    current = 0; _code.Clear();
                    SetPartybalance();
                    dgvHelp.Hide();
                }
            }
            else
            {
                current = 0;
                SetPartybalance();
                dgvHelp.Hide();
            }

        }

        private void Dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {

                Refresh();
            }
        }

        private void RateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_name.Text.Trim() == string.Empty || _code.Text.Trim() == string.Empty || current == 0)
                {
                    this.Error("براہ کرم پارٹی منتخب کریں");
                    _name.Select();
                    e.SuppressKeyPress = true; // Prevents the beep sound
                    return;
                }
                if (_items.SelectedIndex == -1 || _items.SelectedValue == null)
                {
                    this.Error("براہ کرم اشیاء منتخب کریں");
                    _items.Select();
                    e.SuppressKeyPress = true; // Prevents the beep sound
                    return;
                }

                if (_qty.Value.toDecimal() * _rate.Value.toDecimal() == 0)
                {
                    this.Error("براہ کرم تعداد اور ریٹ درج کریں");
                    _qty.Select();
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
                AccountID = current,
                EntryType = rbDebit.Checked ? 0 : 1,
                ItemType = rbSeed.Checked ? 0 : 1,
                Code = _code.Text,
                CreditAmount = _cr.Value.toDecimal(),
                DebitAmount = _dr.Value.toDecimal(),
                ItemID = _items.SelectedValue.toInt(),
                ItemName = _items.Text.Trim(),
                ItemQty = _qty.Value.toDecimal(),
                ItemRate = _rate.Value.toDecimal(),
                PartyName = _name.Text.Trim(),
                Narration = _narration.Text.Trim(),
                ID = 0,
                VoucherID = main.VoucherID
            };
            bsCart.Add(c);
            isChanged = true;
            bsCart.ResetBindings(false);
            clearEntryPanel();
            _name.Select();
        }
        private void CalculateAmount(object sender, EventArgs e)
        {
            bool isDebit = rbDebit.Checked;
            if (isDebit)
            {
                _dr.Clear();
                _cr.Clear();
                decimal qty, rate;
                if (decimal.TryParse(_qty.Text, out qty) && decimal.TryParse(_rate.Text, out rate))
                {
                    _cr.Text = (qty * rate).ProperDecimals();
                }
                else
                {
                    _cr.Clear();
                }
            }
            else
            {
                _dr.Clear();
                _cr.Clear();
                decimal qty, rate;
                if (decimal.TryParse(_qty.Text, out qty) && decimal.TryParse(_rate.Text, out rate))
                {
                    _dr.Text = (qty * rate).ProperDecimals();
                }
                else
                {
                    _dr.Clear();
                }
            }
        }
        private void GetItems(object sender, EventArgs e)
        {
            RefreshItems();
        }

        int current = 0;
        private void clearEntryPanel()
        {
            _code.RegisterFocus(true);
            _name.RegisterFocus(true);
            _cr.RegisterFocus(false);
            _dr.RegisterFocus(false);
            _narration.RegisterFocus(true);
            _items.RegisterFocus(true);
            _qty.RegisterFocus(false);
            _rate.RegisterFocus(false);
            dtp.RegisterFocus(false);
            _code.Clear();
            _name.Clear();
            current = 0;
            SetPartybalance();
            _cr.Clear();
            _dr.Clear();
            _narration.Clear();
            _items.SelectedIndex = -1;
            _qty.Clear();
            _rate.Clear();
            RefreshItems();
            RefreshParties();
        }
        DataTable dtParties = new DataTable();
        private void RefreshParties()
        {
            dtParties = DetailAccountService.PartyAccounts().ToDataTable();
            bsParties.DataSource = dtParties;
        }

        private void RefreshItems()
        {
            string itemtypes = "";
            if (rbSeed.Checked)
            {
                itemtypes = "N'فروٹ',N'سبزی'"; // Fruits and Vegetables
            }
            else
            {
                itemtypes = "N'دیگر اشیاء'"; // Other Items
            }
            bsItems.DataSource = ItemService.GetItems(itemtypes);
        }
        private void FrmBVNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged && !this.Ask("ووچر میں کی گئی تبدیلیاں محفوظ نہیں ہیں، کیا آپ واقعی فارم بند کرنا چاہتے ہیں؟"))
            {
                e.Cancel = true;
            }
        }

        private void FrmBVNew_Resize(object sender, EventArgs e)
        {
            obj._resize();
        }
        public override void Refresh()
        {
            if (dtp.Value.Date < DateTime.Now.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر دیکھنے کی اجازت نہیں ہے۔");
                dtp.Value=DateTime.Now.Date;
                return;
            }
            if (dtp.Value.Date < DateTime.Today.Date && !this.Ask("کیا آپ پُرانا ووچر کھولنا چاہتے ہیں؟"))
            {
                return;
            }
            main = VoucherService.GetVoucher(vType, dtp.Value.Date);
            bsCart.DataSource = main.BardanaEntries;
            bsCart.ResetBindings(false);
            _name.Select();
        }
        private void FrmBVNew_Load(object sender, EventArgs e)
        {
            obj._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
            SetPartybalance();
            dtp.Value = DateTime.Today.Date;
            Refresh();
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (main.VoucherDate.Date != dtp.Value.Date)
            {
                this.Error("A critical error has occurred. Please contact support."); return;
            }
            if (dtp.Value.Date < DateTime.Now.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر محفوظ کرنے کی اجازت نہیں ہے۔");
                return;
            }
            if (dtp.Value.Date < DateTime.Today.Date && !this.Ask("کیا آپ پُرانا ووچر محفوظ کرنا چاہتے ہیں؟"))
            {
                return;
            }


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
            dgv.Validate();
            try
            {
                VoucherService.SaveVoucher(main);
                //finally
                isChanged = false;
                this.Info("ریکارڈ محفوظ ہو گیا ہے۔");
                Refresh();
            }
            catch (Exception ex)
            {
                ex.ExcError("While Saving Voucher...");
            }
        }


    }
}
