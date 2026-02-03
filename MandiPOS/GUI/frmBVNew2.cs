using Dapper;

using DevExpress.XtraEditors.Repository;

using Janus.Windows.GridEX;

using MandiPOS.CLasses;

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MandiPOS.GUI
{
    public partial class frmBVNew2 : Form
    {
        clsResize obj;
        Vouchers main = new Vouchers();
        int vType;
        bool isChanged = false;
        int _stockType = 0;

        public frmBVNew2(int StockType = 0)
        {
            InitializeComponent();
            cmbStock.RightToLeft = RightToLeft.Yes;
            _items.RightToLeft = RightToLeft.Yes;

            _stockType = StockType;
            dtp.Value = SQL.ServerDate.Date;
            dtp.Enabled = General.IsAdmin;
            cmbStock.Enabled = StockType == 1;
            rbDebit.CheckedChanged += CheckEntryMode;
            rbCredit.CheckedChanged += CheckEntryMode;
            txtVno.KeyDown += (s, e) =>
            {
                if (e.EnterKey())
                {
                    RefreshById(txtVno.Value.toInt());
                }
            };
            txtVno.Maximum = decimal.MaxValue;
            txtVno.Enabled = General.IsAdmin;
            vType = 5;
            _wt.Enabled = lblwt.Visible = _wt.Visible = uiCheckBox1.Visible = vType == 3;
            _code.RegisterFocus(true);
            _name.RegisterFocus(true);
            _cr.RegisterFocus(false);
            _dr.RegisterFocus(false);
            _narration.RegisterFocus(true);
            _items.RegisterFocus(true);
            _qty.RegisterFocus(false);
            _rate.RegisterFocus(false);
            dtp.RegisterFocus(false);
            _narration.KeyDown += _narration_KeyDown;
            _qty.KeyDown += ((s, e) =>
            {
                if (e.EnterKey())
                {
                    _rate.Select();
                    _rate.SelectAll();
                }
            });
            _wt.KeyDown += ((s, e) =>
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
            _wt.Enter += (s, e) => { Program.UrduInput(false); };
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
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F5)
                {
                    Refresh();
                }
            };
            _rate.TextChanged += CalculateAmount;
            _wt.TextChanged += CalculateAmount;
            _qty.TextChanged += CalculateAmount;
            _rate.KeyDown += RateKeyDown;
            dtp.KeyDown += Dtp_KeyDown;
            _qty.Leave += ((s, e) =>
            {
                if (_items.SelectedIndex != -1)
                {
                    GetStock(_items.SelectedValue);
                }
            });
            _items.KeyDown += (s, e) =>
            {
                if (e.EnterKey() && _items.SelectedIndex != -1)
                {
                    ValidateStock();
                    if (cmbStock.Enabled)
                    {
                        cmbStock.Select();
                        cmbStock.Focus();
                        cmbStock.DroppedDown = true;
                    }
                    else
                    {
                        _qty.Select();
                        _qty.SelectAll();
                    }

                }
            };
            switch (vType)
            {
                case 3:
                    rbSeed.Checked = true;
                    this.Text = lblType.Text = "بیج ووچر";
                    break;
                case 5:
                    rbOther.Checked = true;
                    this.Text = lblType.Text = "باردانہ ووچر";
                    break;
            }
            switch (StockType)
            {
                case 1:
                    rbCredit.Checked = true;
                    rbDebit.Enabled = false;
                    CheckEntryMode(null, null);
                    break;
                case 0:
                    rbDebit.Checked = true;
                    rbCredit.Enabled = false;
                    CheckEntryMode(null, null);
                    break;
            }
            grpMode.Enabled = false;

        }

        private void ValidateStock()
        {
            GetStock(_items.SelectedValue);

        }

        private void GetStock(object selectedValue)
        {
            if (_stockType == 0)
            {
                bsStock.DataSource = null;
                cmbStock.Enabled = false;
            }
            else
            {
                bsStock.DataSource = new clsStock().GetStock(selectedValue.toInt());
                bsStock.ResetBindings(false);
            }
            int stock = ItemService.GetItemStock(selectedValue.toInt());
            int wtstock = ItemService.GetItemWeightStock(selectedValue.toInt());
            //lblStock.Text = stock == 0 ? "" : stock.ToString();
            //lblwtStock.Text = wtstock == 0 ? "" : wtstock.ToString();
        }

        private void CheckEntryMode(object sender, EventArgs e)
        {
            if (rbDebit.Checked) //Aamad
            {
                rbDebit.BackColor = Color.DodgerBlue;
                rbCredit.BackColor = SystemColors.Control;
                grpMode.BackColor = Color.LightGreen;
                _dr.Enabled = false;
                _cr.Enabled = true;
                _cr.Clear();
            }
            else //Jaamad
            {

                rbCredit.BackColor = Color.DodgerBlue;

                rbDebit.BackColor = SystemColors.Control;
                grpMode.BackColor = Color.LightCoral;
                _dr.Enabled = true;
                _cr.Enabled = false;
                _dr.Clear();
            }
            CalculateAmount(null, null);
        }

        void SetPartybalance()
        {
            if (current != 0 && General.IsAdmin)
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
                    if (!General.IsAdmin && data.EnteredBy != 0 && data.EnteredBy != General.CurrentUserID)
                    {
                        this.Error("You are not allowed to Edit/Delete Other User Entry.");
                        return;
                    }
                    using (var db = new db())
                    {
                        using (var trx = db.BeginTransaction())
                        {
                            try
                            {
                                db.Delete<VoucherBardanaDetails>(data.ID, transaction: trx);
                                trx.Commit();

                            }
                            catch (Exception ex)
                            {
                                trx.Rollback();
                                ex.ExcError(null); return;
                            }
                        }
                    }
                    Refresh();
                    if (data.DebitAmount != 0)
                    {
                        rbCredit.Checked = true;
                    }
                    else
                    {
                        rbDebit.Checked = true;
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
                    if (_stockType == 1)
                    {
                        cmbStock.Value = data.SourceID;
                    }
                    SetPartybalance();
                    _narration.Text = data.Narration;
                    _items.SelectedValue = data.ItemID;
                    _qty.Value = data.ItemQty;
                    _rate.Value = data.ItemRate;
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
            if (e.EscapeKey())
            {
                dgvHelp.Hide();
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
                if (_stockType == 1 && cmbStock.SelectedIndex == -1)
                {
                    this.Error("براہ کرم سٹاک منتخب کریں");
                    cmbStock.Select(); e.SuppressKeyPress = true;
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
                ItemWeight = _wt.Value.toDecimal(),
                ItemRate = _rate.Value.toDecimal(),
                PartyName = _name.Text.Trim(),
                Narration = _narration.Text.Trim(),
                ID = 0,
                VoucherID = main.VoucherID,
                SourceID = (_stockType == 0 ? current : cmbStock.Value.toInt()),
            };

            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    try
                    {
                        Vouchers vmain = db.Query<Vouchers>($"Select Top 1 * from Vouchers Where VoucherType='{vType}' and VoucherDate='{dtp.Value.Date:yyyy-MM-dd}'", transaction: trx).FirstOrDefault() ?? new Vouchers();
                        if (vmain.VoucherID == 0)
                        {
                            vmain = new Vouchers()
                            {
                                VoucherType = vType.ToString(),
                                CreatedBy = General.CurrentUserID.ToString(),
                                CreatedDate = DateTime.Now,
                                VoucherDate = dtp.Value.Date,
                                VoucherNo = db.ExecuteScalar<string>($"SELECT CAST(ISNULL(MAX(CAST(VoucherNo AS INT)), 0) + 1 AS NVARCHAR) AS NextCode FROM Vouchers Where VoucherType='{vType}'", transaction: trx)
                            };
                            db.Insert<Vouchers>(vmain, transaction: trx);
                        }
                        VoucherBardanaDetails d = new VoucherBardanaDetails()
                        {
                            DebitAmount = c.DebitAmount,
                            ItemRate = c.ItemRate,
                            Narration = c.Narration,
                            AccountID = c.AccountID,
                            CreditAmount = c.CreditAmount,
                            ItemDescription = c.ItemDescription,
                            ItemID = c.ItemID,
                            ItemQty = c.ItemQty,
                            ItemWeight = c.ItemWeight,
                            VoucherID = vmain.VoucherID,
                            EnteredBy = General.CurrentUserID,
                            sourceId = c.SourceID
                        };
                        db.Insert<VoucherBardanaDetails>(d, transaction: trx);
                        trx.Commit();
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        ex.ExcError(null);
                        return;
                    }
                }
            }
            Refresh();
            clearEntryPanel(); _name.Select();
        }
        private void CalculateAmount(object sender, EventArgs e)
        {
            bool isDebit = rbDebit.Checked;
            decimal qty, rate, wt, Amount;
            decimal.TryParse(_qty.Text, out qty);
            decimal.TryParse(_rate.Text, out rate);
            decimal.TryParse(_wt.Text, out wt);
            _dr.Clear();
            _cr.Clear();
            if (wt == 0)
            {
                Amount = (qty * rate);
            }
            else
            {
                Amount = (wt * rate);
            }
            if (isDebit)
            {
                _cr.Text = (Amount).ProperDecimals();
            }
            else
            {
                _dr.Text = (Amount).ProperDecimals();
            }
        }
        private void GetItems(object sender, EventArgs e)
        {
            RefreshItems();
        }

        int current = 0;
        private void clearEntryPanel()
        {

            // _code.Clear();
            // _name.Clear();
            //current = 0;
            // SetPartybalance();
            // _cr.Clear();
            // _dr.Clear();
            // _narration.Clear();
            // _items.SelectedIndex = -1;
            //_qty.Clear();
            //_rate.Clear();
            //lblStock.Text = lblwtStock.Text = "";
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
            return;
            if (isChanged && !this.Ask("ووچر میں کی گئی تبدیلیاں محفوظ نہیں ہیں، کیا آپ واقعی فارم بند کرنا چاہتے ہیں؟"))
            {
                e.Cancel = true;
            }
            if (e.CloseReason != CloseReason.UserClosing)
                return;
            decimal dr = main.BardanaEntries.Sum(x => x.DebitAmount);
            decimal cr = main.BardanaEntries.Sum(x => x.CreditAmount);
            if (dr != cr)
            {
                this.Error("جمع اور بنام کی رقم برابر نہیں۔ دوبارہ کوشش کریں۔");
                e.Cancel = true;
                return;
            }
        }

        private void FrmBVNew_Resize(object sender, EventArgs e)
        {
            obj._resize();
        }
        public override void Refresh()
        {
            if (dtp.Value.Date < SQL.ServerDate.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر دیکھنے کی اجازت نہیں ہے۔");
                dtp.Value = DateTime.Now.Date;
                return;
            }
            if (dtp.Value.Date < DateTime.Today.Date && !this.Ask("کیا آپ پُرانا ووچر کھولنا چاہتے ہیں؟"))
            {
                return;
            }
            main = VoucherService.GetVoucher(vType, dtp.Value.Date);
            txtVno.Value = main.VoucherNo.toDecimal();
            bsCart.DataSource = main.BardanaEntries.OrderByDescending(x => x.ID);
            bsCart.ResetBindings(false);
            CheckState();
            _name.Select();
        }
        void RefreshById(int id)
        {
            var voucher = VoucherService.GetVoucherByNo(vType, id);
            if (voucher.VoucherDate.Date < SQL.ServerDate.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر دیکھنے کی اجازت نہیں ہے۔");
                dtp.Value = DateTime.Now.Date;
                return;
            }
            if (voucher.VoucherDate.Date < DateTime.Today.Date && !this.Ask("کیا آپ پُرانا ووچر کھولنا چاہتے ہیں؟"))
            {
                return;
            }
            main = voucher;
            dtp.Value = main.VoucherDate.Date;
            txtVno.Value = main.VoucherNo.toDecimal();
            bsCart.DataSource = main.BardanaEntries.OrderByDescending(x => x.ID);
            bsCart.ResetBindings(false);
            _name.Select();
        }
        private void FrmBVNew_Load(object sender, EventArgs e)
        {

            obj._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
            SetPartybalance();
            dtp.Value = DateTime.Today.Date;
            txtVno.Value = SQL.GetNextVoucherNo(vType).toDecimal();
            CheckEntryMode(null, null);
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateStock();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (main.VoucherID == 0)
                return;
            using (var frm = new frmDateChanger(vType, main.VoucherID, main.VoucherDate))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckState();
        }

        private void CheckState()
        {
            _wt.Enabled = uiCheckBox1.Checked;
        }
    }
}
