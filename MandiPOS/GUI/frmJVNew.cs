

using Dapper;
using Janus.Windows.GridEX;

using MandiPOS.CLasses;
using MandiPOS.Reports;
using System;
using System.Collections.Generic;
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
        string _title = "جنرل ووچر";
        bool _verified = false;
        bool verified
        {
            get 
            {
                if (!_verified)
                { 
                    _verified=this.IsVerified();
                }
                return _verified;
            }
        }
        public frmJVNew()
        {
            InitializeComponent();
            txtVoucherNumber.KeyDown += TxtVoucherNumber_KeyDown;
            this.FormClosing += FrmJVNew_FormClosing;
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
            this.Text = _title;
            dtp.Value = SQL.ServerDate.Date;
            dtp.Enabled = General.IsAdmin;
            objResizer = new clsResize(this);
            _name.TextChanged += _name_TextChanged;
            this.Load += FrmJVNew_Load;
            this.Resize += FrmJVNew_Resize;
            _name.KeyDown += _name_KeyDown;
            dgvHelp.KeyDown += DgvHelp_KeyDown;

        }

        private void TxtVoucherNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtVoucherNumber.Value.toInt() != 0)
            {
                var v = VoucherService.GetVoucherByNo(VoucherType, txtVoucherNumber.Value.toInt());
                if (v != null)
                {
                    dtp.Value = v.VoucherDate.Date;
                    Refresh();
                }
            }
        }

        private void FrmJVNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;
            decimal dr = main.JVEntries.Sum(x => x.DebitAmount);
            decimal cr = main.JVEntries.Sum(x => x.CreditAmount);
            if (dr != cr)
            {
                this.Error("جمع اور بنام کی رقم برابر نہیں۔ دوبارہ کوشش کریں۔");
                e.Cancel = true;
                return;
            }
        }

        void SetPartybalance()
        {
            if (curent != 0 && General.IsAdmin)
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
                    using (var db = new db())
                    {
                        using (var trx = db.BeginTransaction())
                        {
                            try
                            {

                                db.Execute($"Delete From JVentries Where VoucherID={CurrentID} and ID={c.id}", transaction: trx);
                                trx.Commit();
                                _name.Text = c.PartyTitle;
                                _code.Text = c.AccountCode;
                                _narration.Text = c.Narration;
                                _cr.Text = c.CreditAmount.ToString("0.##");
                                _dr.Text = c.DebitAmount.ProperDecimals();
                                curent = c.AccountID;
                                SetPartybalance();
                                Refresh();
                                _name.Select(); Program.UrduInput(true);
                            }
                            catch (Exception ex)
                            {
                                trx.Rollback();
                                ex.ExcError();
                            }
                        }
                    }


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
                bool flowControl = AddToCart();
                if (!flowControl)
                {
                    return;
                }
            }
        }

        private bool AddToCart()
        {
            if (curent == 0 || _name.Text.Trim() == string.Empty || _code.Text.Trim().toInt() == 0)
            {
                MessageBox.Show("براہ کرم پارٹی کا انتخاب کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _name.Select();
                return false;
            }
            if (_dr.Text.toDecimal() == 0 && _cr.Text.toDecimal() == 0)
            {
                MessageBox.Show("براہ کرم رقم درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _dr.Select();
                return false;
            }
            if (_dr.Text.toDecimal() > 0 && _cr.Text.toDecimal() > 0)
            {
                MessageBox.Show("براہ کرم  جمع یا بنام میں سے ایک رقم درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _dr.Select();
                return false;
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
                        if (vmain.VoucherID == 0)
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
                            AccountID = c.AccountID,
                            CreditAmount = c.CreditAmount,
                            DebitAmount = c.DebitAmount,
                            Narration = c.Narration,
                            VoucherID = vmain.VoucherID,
                            EnteredBy = General.CurrentUserID,
                        };
                        db.Insert<JVEntries>(d, transaction: trx);
                        trx.Commit();
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        ex.ExcError(null);
                        return false;
                    }
                }
            }
            main = VoucherService.GetVoucher(VoucherType, dtp.Value);
            txtVoucherNumber.Value = main.VoucherNo.toDecimal(); ;
            bs.DataSource = main.JVEntries;
            bs.ResetBindings(false);
            // _narration.Clear();
            //_name.Clear();
            //_dr.Text = 0.ToString("0.##");
            //_cr.Text = 0.ToString("0.##");
            _name.Select(); Program.UrduInput(true); _name.SelectAll();
            return true;
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
        int CurrentID = 0;
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
            if (dtp.Value.Date < SQL.ServerDate.Date && !General.IsAdmin)
            {
                this.Info("آپکو پرانا ووچر دیکھنے کی اجازت نہیں ہے۔");
                dtp.Value = SQL.ServerDate.Date;
                return;
            }
            if (dtp.Value.Date < SQL.ServerDate.Date && !verified)
            {
                return;
            }
            main = VoucherService.GetVoucher(VoucherType, dtp.Value);
            txtVoucherNumber.Value = main.VoucherNo.toDecimal();
            CurrentID = main.VoucherID;
            bs.DataSource = main.JVEntries;
            dtParties = DetailAccountService.GetAccountsViewList(0, false).ToDataTable();
            bsParties.DataSource = dtParties;
            bsParties.ResetBindings(false);
            bs.ResetBindings(false);
            _name.Select();
        }
        private void FrmJVNew_Resize(object sender, System.EventArgs e)
        {
            objResizer._resize();
            foreach (GridEXColumn col in dgv.RootTable.Columns)
            {
                col.AllowSize = true;
                if (col.Key == "AccountCode")
                {
                    col.Width = _code.Width;
                    col.AllowSize = false;
                }
                if (col.Key == "PartyTitle")
                {
                    col.Width = _name.Width;
                    col.AllowSize = false;
                }
                if (col.Key == "DebitAmount")
                {
                    col.Width = _dr.Width;
                    col.AllowSize = false;
                }
                if (col.Key == "CreditAmount")
                {
                    col.Width = _cr.Width;
                    col.AllowSize = false;
                }
            }
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
            //if (dtp.Value.Date < SQL.ServerDate.Date && !General.IsAdmin)
            //{
            //    this.Info("آپکو پرانا ووچر محفوظ کرنے کی اجازت نہیں ہے۔");
            //    return;
            //}
            if (dtp.Value.Date < SQL.ServerDate.Date && !this.verified)
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
                this.Close(); return;
            }
            else
            {
                MessageBox.Show("ریکارڈ محفوظ کرنے میں مسئلہ پیش آہا۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (main.VoucherID == 0)
                return;
            using (var frm = new frmDateChanger(VoucherType, main.VoucherID, main.VoucherDate))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }

        private void OpenDateChanger(object sender, EventArgs e)
        {
            if (main.VoucherID == 0)
                return;
            using (var frm = new frmDateChanger(VoucherType, main.VoucherID, main.VoucherDate))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (bs.Count > 0)
            {
                using (new crsr())
                {
                    using (var rpt = new rptJVPrint(bs.List.Cast<JVCart>().ToList(), title: _title, vno: txtVoucherNumber.Value.ToString(), date: dtp.Value.ToString("dd-MM-yyyy")))
                    {
                        using (var frm = new XtraForm1(rpt, 1.5f))
                        {
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog(this); frm.BringToFront();
                        }
                    } 
                }
            }
        }
    }
}
