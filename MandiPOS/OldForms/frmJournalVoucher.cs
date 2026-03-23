using Janus.Windows.GridEX;

using MandiPOS.CLasses;

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmJournalVoucher : Form
    {
        int VoucherType = 2;
        Vouchers main = new Vouchers();
        clsResize resize;
        public frmJournalVoucher()
        {
            InitializeComponent();
            resize = new clsResize(this);
            this.Text = "Journal Voucher";
            this.Load += FrmJournalVoucher_Load;
            this.Resize += FrmJournalVoucher_Resize;
            dt.ValueChanged += Dt_ValueChanged;
            dt.Value = DateTime.Now;
            Cr.TextChanged += Dr_TextChanged;
            Dr.TextChanged += Cr_TextChanged;
            Cr.EditValueChanged += Dr_TextChanged;
            Dr.EditValueChanged += Cr_TextChanged;
        }

        private void FrmJournalVoucher_Resize(object sender, EventArgs e)
        {
            resize._resize();
        }

        private void Cr_TextChanged(object sender, EventArgs e)
        {
            if (Cr.Focused && Cr.Text.toDecimal() > 0)
            {
                Dr.Text = "0";
            }
        }

        private void Dr_TextChanged(object sender, EventArgs e)
        {
            if (Dr.Focused && Dr.Text.toDecimal() > 0)
            {
                Cr.Text = "0";
            }
        }

        private void Dt_ValueChanged(object sender, EventArgs e)
        {
            main = VoucherService.GetVoucher(VoucherType, dt.Value);
            bs.DataSource = main.JVEntries;
            bs.ResetBindings(false);
            cmbParty.Select();
        }

        private void FrmJournalVoucher_Load(object sender, EventArgs e)
        {
            resize._get_initial_size();
            bsAccounts.DataSource = DetailAccountService.GetAccountsViewList();

        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbParty.EditValue == null || cmbParty.EditValue.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("براہ کرم پارٹی کا انتخاب کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbParty.Select();
                    return;
                }
                if (Cr.EditValue.toDecimal() == 0 && Dr.EditValue.toDecimal() == 0)
                {
                    MessageBox.Show("براہ کرم رقم درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cr.Select();
                    return;
                }
                if (Cr.Text.toDecimal() > 0 && Dr.Text.toDecimal() > 0)
                {
                    MessageBox.Show("براہ کرم  جمع یا بنام میں سے ایک رقم درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cr.Select();
                    return;
                }
                JVCart c = new JVCart()
                {
                    AccountID = cmbParty.EditValue.toInt(),
                    PartyTitle = cmbParty.Text.Trim(),
                    CreditAmount = Cr.EditValue.toDecimal(),
                    DebitAmount = Dr.EditValue.toDecimal(),
                    Narration = txtNarration.Text.Trim(),
                    AccountCode = txtCode.Text.Trim()
                };
                bs.Add(c);
                bs.ResetBindings(false);
                cmbParty.EditValue = null;
                txtNarration.Clear();
                Dr.EditValue = 0;
                Cr.EditValue = 0;
                cmbParty.Select();
            }
        }

        private void cmbParty_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbParty.EditValue == null) { txtCode.Clear(); return; }
            else
            {
                var acc = bsAccounts.Current as DetailAccountView;
                if (acc != null)
                {
                    txtCode.Text = acc.AccountCode.ToString();
                }
            }
        }

        private void txtNarration_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void cmbParty_Enter(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void gridEX1_DoubleClick(object sender, EventArgs e)
        {
            if (gridEX1.CurrentRow.RowIndex != -1 && gridEX1.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                JVCart c = gridEX1.CurrentRow.DataRow as JVCart;
                if (c != null)
                {
                    cmbParty.EditValue = c.AccountID;
                    txtNarration.Text = c.Narration;
                    Dr.EditValue = c.CreditAmount;
                    Cr.EditValue = c.DebitAmount;
                    bs.Remove(c);
                    bs.ResetBindings(false);
                    cmbParty.Select();
                }
            }
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
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

        private void uiButton1_Click(object sender, EventArgs e)
        {
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
            main.VoucherDate = dt.Value;
            main.VoucherType = VoucherType;
            main.JVEntries = bs.List.Cast<JVCart>().ToList();
            if (VoucherService.SaveVoucher(main))
            {
                MessageBox.Show("ریکارڈ کامیابی سے محفوظ ہو گیا۔", "کامیابی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dt_ValueChanged(null, null);
            }
            else
            {
                MessageBox.Show("ریکارڈ محفوظ کرنے میں مسئلہ پیش آہا۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbParty.Select();
            }
        }
    }
}
