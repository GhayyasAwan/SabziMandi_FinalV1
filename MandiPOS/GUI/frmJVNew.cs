using Dapper;

using Janus.Windows.GridEX;

using MandiPOS.CLasses;

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmJVNew : Form
    {
        clsResize objResizer;
        int VoucherType = 2;
        Vouchers main = new Vouchers(); int curent = 0;
        public frmJVNew()
        {
            InitializeComponent();
            SetPartybalance();
            _narration.RegisterFocus(true);
            _name.RegisterFocus(true);
            _dr.RegisterFocus(false);
            _cr.RegisterFocus(false);
            dgv.FormattingRow += Dgv_FormattingRow;
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            _narration.KeyDown += _narration_KeyDown;
            _dr.KeyDown += _dr_KeyDown;
            _name.Enter += _name_Enter; _narration.Enter += _narration_Enter; _cr.Enter += _cr_Enter; _dr.Enter += _dr_Enter;
            _name.Leave += _name_Leave;
            _cr.KeyDown += _cr_KeyDown;
            _cr.TextChanged += _cr_TextChanged;
            _dr.TextChanged += _dr_TextChanged;
            this.Text = "Journal Voucher";
            dtp.Value = DateTime.Now;
            objResizer = new clsResize(this);
            _name.TextChanged += _name_TextChanged;
            this.Load += FrmJVNew_Load;
            this.Resize += FrmJVNew_Resize;
            _name.KeyDown += _name_KeyDown;
            dgvHelp.KeyDown += DgvHelp_KeyDown;

        }
        void SetPartybalance()
        {
            if (curent != 0)
            {
                partyBal.Text = this.GetPartyBalance(curent);
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
        private void Dgv_FormattingRow(object sender, RowLoadEventArgs e)
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
                if (e.Row.Cells["Narration"] != null)
                {
                    e.Row.Cells["Narration"].Text = difference.ToString("0.##");

                    if (difference != 0)
                    {
                        e.Row.Cells["Narration"].FormatStyle = new GridEXFormatStyle
                        {
                            BackColor = Color.LightCoral,
                            ForeColor = Color.White,
                            FontBold = TriState.True,
                            TextAlignment = TextAlignment.Far
                        };
                    }
                    else
                    {
                        e.Row.Cells["Narration"].FormatStyle = new GridEXFormatStyle
                        {
                            BackColor = SystemColors.Info,
                            ForeColor = Color.Black,
                            FontBold = TriState.False,
                            TextAlignment = TextAlignment.Far
                        };
                    }
                }
            }
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv.IsRow())
            {
                JVCart c = dgv.CurrentRow.DataRow as JVCart;
                if (c != null)
                {
                    _name.Text = c.PartyTitle;
                    _code.Text = c.AccountCode;
                    _narration.Text = c.Narration;
                    _dr.Text = c.CreditAmount.ToString("0.##");
                    _dr.Text = c.DebitAmount.ProperDecimals();
                    curent = c.AccountID;
                    SetPartybalance();
                    bs.Remove(c);
                    bs.ResetBindings(false);
                    _name.Select(); Program.UrduInput(true);
                }
            }
        }

        private void _dr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _cr.Select();
            }
        }

        private void _narration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.EnterKey())
            {
                _dr.Select();
            }
        }

        private void _dr_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(false);
            _dr.SelectAll();
        }

        private void _cr_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(false);
            _cr.SelectAll();
        }


        private void _narration_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void _name_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void _name_Leave(object sender, EventArgs e)
        {

        }

        private void _cr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (curent == 0 || _name.Text.Trim() == string.Empty || _code.Text.Trim().toInt() == 0)
                {
                    MessageBox.Show("براہ کرم پارٹی کا انتخاب کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _name.Select();
                    return;
                }
                if (_dr.Text.toDecimal() == 0 && _cr.Text.toDecimal() == 0)
                {
                    MessageBox.Show("براہ کرم رقم درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _dr.Select();
                    return;
                }
                if (_dr.Text.toDecimal() > 0 && _cr.Text.toDecimal() > 0)
                {
                    MessageBox.Show("براہ کرم  جمع یا بنام میں سے ایک رقم درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _dr.Select();
                    return;
                }
                JVCart c = new JVCart()
                {
                    AccountID = curent,
                    PartyTitle = _name.Text.Trim(),
                    CreditAmount = _cr.Text.toDecimal(),
                    DebitAmount = _dr.Text.toDecimal(),
                    Narration = _narration.Text.Trim(),
                    AccountCode = _code.Text.Trim()
                };
                using (var db = new db())
                {
                    using (var trx = db.BeginTransaction())
                    {
                        try
                        {
                            Vouchers vmain = db.Query<Vouchers>($"Select Top 1 * from Vouchers Where VoucherType='{VoucherType}' and VoucherDate='{dtp.Value.Date:yyyy-MM-dd}'", transaction: trx).FirstOrDefault() ?? new Vouchers();
                            if (main.VoucherID == 0)
                            {
                                vmain = new Vouchers()
                                {
                                    VoucherType = VoucherType.ToString(),
                                    CreatedBy = General.CurrentUserID.ToString(),
                                    CreatedDate = DateTime.Now,
                                    VoucherDate = dtp.Value.Date,
                                    VoucherNo = db.ExecuteScalar<string>($"SELECT CAST(ISNULL(MAX(CAST(VoucherNo AS INT)), 0) + 1 AS NVARCHAR) AS NextCode FROM Vouchers Where VoucherType='{VoucherType}'", transaction: trx)
                                };
                                db.Insert<Vouchers>(vmain, transaction: trx);
                            }
                            JVEntries d = new JVEntries()
                            {
                                 AccountID=c.AccountID, CreditAmount=c.CreditAmount, 
                                  DebitAmount=c.DebitAmount, Narration=c.Narration, VoucherID=vmain.VoucherID, EnteredBy = General.CurrentUserID,
                            };
                            db.Insert<JVEntries>(d, transaction: trx);
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



                bs.Add(c);
                bs.ResetBindings(false);
                _narration.Clear();
                _name.Clear();
                _dr.Text = 0.ToString("0.##");
                _cr.Text = 0.ToString("0.##");
                _name.Select(); Program.UrduInput(true);
            }
        }

        private void _dr_TextChanged(object sender, EventArgs e)
        {
            if (_dr.Focused && _dr.Text.toDecimal() > 0)
            {
                _cr.Text = 0.ToString("0.##");
            }
        }

        private void _cr_TextChanged(object sender, EventArgs e)
        {
            if (_cr.Focused && _cr.Text.toDecimal() > 0)
            {
                _dr.Text = 0.ToString("0.##");
            }
        }

        private void DgvHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvHelp.IsRow())
                {
                    var dr = dtParties.Select($"ID='{dgvHelp.RecordID()}'");
                    if (dr.Length > 0)
                    {
                        var row = dr[0];
                        _name.Text = row["AccountTitle"].ToString();
                        _code.Text = row["AccountCode"].ToString();
                        curent = row["ID"].ToString().toInt();
                        SetPartybalance();
                        _name.Select();
                        dgvHelp.Visible = false;
                    }
                }
            }
        }

        private void _name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _narration.Focus();
            }
            if (e.KeyCode == Keys.Escape && dgvHelp.Visible)
            {
                dgvHelp.Visible = false;
            }
            if (e.KeyCode == Keys.Down && dgvHelp.Visible)
            {
                dgvHelp.Select();
            }
            if (e.KeyCode == Keys.Down && !dgvHelp.Visible)
            {
                dgv.Select();
            }
        }
        DataTable dtParties = new DataTable();
        public override void Refresh()
        {
            if (dtp.Value.Date < DateTime.Now.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر دیکھنے کی اجازت نہیں ہے۔");
                dtp.Value = DateTime.Now.Date;
                return;
            }
            if (dtp.Value.Date < DateTime.Now.Date && !this.Ask("کیا آپ پُرانا ووچر کھولنا چاہتے ہیں؟"))
            {
                return;
            }

            main = VoucherService.GetVoucher(VoucherType, dtp.Value);
            bs.DataSource = main.JVEntries;
            dtParties = DetailAccountService.GetAccountsViewList().ToDataTable();
            bsParties.DataSource = dtParties;
            bsParties.ResetBindings(false);
            bs.ResetBindings(false);
            _name.Select();
        }
        private void FrmJVNew_Resize(object sender, System.EventArgs e)
        {
            objResizer._resize();
        }

        private void FrmJVNew_Load(object sender, System.EventArgs e)
        {
            objResizer._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
            Refresh();
        }

        private void _name_TextChanged(object sender, System.EventArgs e)
        {
            if (_name.Focused & _name.Text.Length > 0)
            {
                dgvHelp.Visible = true;
                bsParties.Filter = $"AccountTitle Like '%{_name.Text.Trim()}%'";
                bsParties.ResetBindings(false);
            }
            else if (_name.Focused && _name.Text.Length == 0)
            {
                _code.Clear();
                dgvHelp.Visible = false;
            }
            else if (_name.Text.Length == 0)
            {
                _code.Clear();
            }
            curent = 0; SetPartybalance();
        }

        private void dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Refresh();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (dtp.Value.Date < DateTime.Now.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر محفوظ کرنے کی اجازت نہیں ہے۔");
                return;
            }
            if (dtp.Value.Date < DateTime.Now.Date && !this.Ask("کیا آپ پُرانا ووچر محفوظ کرنا چاہتے ہیں؟"))
            {
                return;
            }
            if (bs.Count == 0)
            {
                MessageBox.Show("براہ کرم کم از کم ایک اندراج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal totalDebit = 0;
            decimal totalCredit = 0;
            foreach (JVCart item in bs.List)
            {
                totalDebit += item.DebitAmount;
                totalCredit += item.CreditAmount;
            }
            if (totalDebit != totalCredit)
            {
                MessageBox.Show("مجموعی جمع اور بنام کی رقم برابر نہیں ہے۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            main.VoucherDate = dtp.Value;
            main.VoucherType = VoucherType.ToString();
            main.JVEntries = bs.List.Cast<JVCart>().ToList();
            if (VoucherService.SaveVoucher(main))
            {
                MessageBox.Show("ریکارڈ کامیابی سے محفوظ ہو گیا۔", "کامیابی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh();
            }
            else
            {
                MessageBox.Show("ریکارڈ محفوظ کرنے میں مسئلہ پیش آہا۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
