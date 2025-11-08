using MandiPOS.CLasses;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmAccountsNew : Form
    {
        clsResize objResizer; private int _masterID = 0;
        public event EventHandler MasterIDChanged;
        DetailAccounts account = new DetailAccounts();
        public int MasterID
        {
            get => _masterID;
            set
            {
                if (_masterID != value)
                {
                    _masterID = value;
                    OnMasterIDChanged(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnMasterIDChanged(EventArgs e)
        {
            if (!isloading)
            {
                MasterIDChanged?.Invoke(this, e);
            }
        }
        bool isloading = false;
        public frmAccountsNew()
        {
            InitializeComponent();
            txtCode.RegisterFocus(true);
            txtName.RegisterFocus(true);
            txtContact.RegisterFocus(true);
            txtCommisionRatio.RegisterFocus(true);
            txtCredit.RegisterFocus(true);
            txtCreditLimit.RegisterFocus(true);
            txtDebit.RegisterFocus(true);
            txtRefName.RegisterFocus(true);
            txtRemarks.RegisterFocus(true);
            cmbCity.RegisterFocus(true);
            cmbRefParty.RegisterFocus(true);



            cmbRefParty.Enter += CmbRefParty_Enter;
            txtRefName.Enter += TxtRefName_Enter;
            dgv.KeyDown += Dgv_KeyDown;
            dgv.RowDoubleClick += Dgv_RowDoubleClick;
            txtCode.ReadOnly = true;
            txtCode.TabStop = false;
            dgv.Click += Dgv_Click;
            cmbRefParty.SelectedIndexChanged += CmbRefParty_SelectedIndexChanged;
            this.Resize += FrmAccountsNew_Resize;
            this.MasterIDChanged += (s, e) =>
            {
                if (!isloading)
                {
                    ResetControls();
                }
            };
            this.Load += FrmAccountsNew_Load;
            txtName.Enter += SwitchToUrdu;
            cmbCity.Enter += SwitchToUrdu;
            txtRemarks.Enter += SwitchToUrdu;
            txtContact.Enter += SwitchToEnglish;

            cmbRefParty.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Select();
                }
            });
            txtRefName.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Select();
                }
            });
            rbOther.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRefName.Focus();
                }
            });
            rbVendor.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRefParty.Select();
                }
            });
            rbCustomer.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRefParty.Focus();
                }
            });
            txtName.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtName.Parent.SelectNextControl(txtName, true, true, true, true);
                }
            });
            txtContact.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtContact.Parent.SelectNextControl(txtContact, true, true, true, true);
                }
            });
            cmbCity.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCity.Parent.SelectNextControl(cmbCity, true, true, true, true);
                }
            });
            txtCredit.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCredit.Parent.SelectNextControl(txtCredit, true, true, true, true);
                }
            });
            txtDebit.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDebit.Parent.SelectNextControl(txtDebit, true, true, true, true);
                }
            });
            txtCreditLimit.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCreditLimit.Parent.SelectNextControl(txtCreditLimit, true, true, true, true);
                }
            });
            txtRemarks.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Parent.SelectNextControl(txtRemarks, true, true, true, true);
                }
            });
            txtCommisionRatio.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaveRecord();
                }
            });
        }

        private void CmbRefParty_Enter(object sender, EventArgs e)
        {
            this.SwitchToUrdu();
        }

        private void TxtRefName_Enter(object sender, EventArgs e)
        {
            this.SwitchToUrdu();
        }

        private void Dgv_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (dgv.CurrentRow != null && dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                EditCurrent();

            }
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv.CurrentRow != null && dgv.CurrentRow.RowIndex != -1 && dgv.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EditCurrent();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteCurrent();
                }

            }
        }

        private void DeleteCurrent()
        {
            if (this.Delete("پارٹی") && DetailAccountService.DeleteDetailAccount(dgv.GetValue(0).toInt()))
            {
                ResetControls();
            }
        }

        private void Dgv_Click(object sender, EventArgs e)
        {

        }

        private void EditCurrent()
        {
            account = SQL.GetDetailsAccountByID(dgv.GetValue(0));
            if (account != null)
            {
                BindObject();
            }
        }

        //private void BindControls()
        //{
        //    txtCode.Text = account.AccountCode.ToString();
        //    txtName.Text = account.AccountTitle;
        //    txtContact.Text = account.Contact;
        //    txtCredit.Text = account.OpCredit.ToString("0.##");
        //    txtDebit.Text = account.OpDebit.ToString("0.##");
        //    txtRemarks.Text = account.Remarks;
        //    txtCommisionRatio.Text = account.Commission.ToString("0.##");
        //    cmbCity.SelectedValue = account.CityID;
        //    switch (account.RefrenceType)
        //    {
        //        case 0: rbOther.Checked = true; break;
        //        case 7: rbCustomer.Checked = true; break;
        //        case 4: rbOther.Checked = true; break;
        //    }
        //    cmbRefParty.SelectedValue = account.RefrenceID;
        //}

        private void CmbRefParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRefName.Text = cmbRefParty.Text.Trim();
        }

        private void SaveRecord()
        {
            ControlsToObject();
            if (!EntryValid())
            {
                return;
            }
            if (account.ID == 0)
            {
                account.MasterID = MasterID;
                DetailAccountService.SaveDetailAccount(account);
                ResetControls();
            }
            else
            {
                DetailAccountService.SaveDetailAccount(account);
                ResetControls();
            }
        }

        private bool EntryValid()
        {
            if (string.IsNullOrEmpty(account.AccountTitle))
            {
                return this.Error("اکاؤنٹ ٹائٹل منتخب کریں");
            }
            if (account.CityID == 0)
            {
                return this.Error("شہر منتخب کریں");
            }
            if ((account.RefrenceType == 7 || account.RefrenceType == 4) && account.RefrenceID == 0)
            {
                return this.Error("معرفت کا کھاتہ منتخب کریں۔");
            }
            return true;
        }

        private void ControlsToObject()
        {
            account.AccountCode = txtCode.Text.toInt();
            account.AccountTitle = txtName.Text.Trim();
            account.Contact = txtContact.Text.Trim();
            account.CityID = cmbCity.SelectedValue.toInt();
            account.OpCredit = txtCredit.Text.toDecimal();
            account.OpDebit = txtDebit.Text.toDecimal();
            account.Remarks = txtRemarks.Text.Trim();
            account.CreditLimit = txtCreditLimit.Text.toDecimal();
            account.Commission = txtCommisionRatio.Text.toDecimal();
            if (rbCustomer.Checked)
            {
                account.RefrenceType = 7;
                account.RefrenceID = cmbRefParty.SelectedValue.toInt();
                account.RefName = txtRefName.Text.Trim();
            }
            else if (rbVendor.Checked)
            {

                account.RefrenceType = 4;
                account.RefrenceID = cmbRefParty.SelectedValue.toInt();
                account.RefName = txtRefName.Text.Trim();
            }
            else
            {
                account.RefrenceType = 0;
                account.RefrenceID = null;
                account.RefName = txtRefName.Text.Trim();
            }

        }
        private void SwitchToUrdu(object sender, EventArgs e)
        {
            Program.UrduInput(true);
        }

        private void SwitchToEnglish(object sender, EventArgs e)
        {
            Program.UrduInput(false);
        }

        private void FrmAccountsNew_Load(object sender, EventArgs e)
        {
            PopulateMasterAccounts();
            ResetControls();
            isloading = false;
            objResizer = new clsResize(this);
            objResizer._get_initial_size();
            txtName.Select();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmAccountsNew_Resize(object sender, System.EventArgs e)
        {
            objResizer._resize();
        }

        public void ResetControls()
        {
            bsCity.DataSource = SQL.GetCities();
            cmbCity.SelectedIndex = -1;
            account = new DetailAccounts();
            Refresh();
        }
        private void PopulateMasterAccounts()
        {
            var master = MasterAccountsService.GetMasterAccounts(" where ID=4");
            bool isFirst = true;
            foreach (var acc in master)
            {
                Button btn = new Button()
                {
                    Size = new Size(150, 50),
                    Text = $"{acc.ID} - {acc.AccountTitle}",
                    Tag = acc.ID,
                    Font = new Font("Jameel Noori nastaleeq", 14),
                    //VisualStyleManager = this.visualStyleManager1,
                    RightToLeft = RightToLeft.Yes,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                btn.Click += Btn_Click;
                if (isFirst)
                {
                    btn.PerformClick();
                    isFirst = false;
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        public override void Refresh()
        {
            if (MasterID != 0)
            {
                if (!isloading)
                {
                    bsAccount1.DataSource = DetailAccountService.GetAccountsViewList(MasterID).OrderByDescending(x=>x.AccountCode).ToDataTable();
                }
                bsAccount1.RemoveFilter();
                dgv.AutoSizeColumns();
                account = new DetailAccounts() { AccountCode = DetailAccountService.GenerateNextAccountCode(MasterID).toInt() };
                BindObject();

            }
        }

        private void BindObject()
        {
            txtCode.Text = account.AccountCode.ToString();
            txtName.Text = account.AccountTitle;
            txtContact.Text = account.Contact;
            txtCredit.Text = (account.OpCredit).ToString("0.##");
            txtDebit.Text = (account.OpDebit).ToString("0.##");
            txtCreditLimit.Text = (account.CreditLimit).ToString("0.##");
            cmbCity.SelectedValue = account.CityID;
            txtRemarks.Text = account.Remarks;
            txtCommisionRatio.Text = (account.Commission).ToString("0.##");
            if (!account.RefrenceType.HasValue) { account.RefrenceType = 0; }
            switch ((int)account.RefrenceType)
            {
                case 4: rbVendor.Checked = true; break;
                case 7: rbCustomer.Checked = true; break;
                default: rbOther.Checked = true; break;
            }
            txtRefName.Text = account.RefName;
            cmbRefParty.SelectedValue = account.RefrenceID;
            txtName.Select();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            MasterID = 0;
            if (sender is Button btn)
            {
                MasterID = btn.Tag.toInt();
            }
        }

        private void rbVendor_CheckedChanged(object sender, EventArgs e)
        {
            CheckRefType();
        }

        private void CheckRefType()
        {
            if (rbVendor.Checked)
            {
                bss.DataSource = SQL.GetDetailsAccounts(4).OrderBy(x => x.AccountTitle).ToList();
                bss.ResetBindings(false);
                cmbRefParty.SelectedValue = account.RefrenceID;
                cmbRefParty.Visible = true;
                txtRefName.Visible = false;
            }
            else if (rbCustomer.Checked)
            {
                bss.DataSource = SQL.GetDetailsAccounts(7).OrderBy(x => x.AccountTitle).ToList();
                bss.ResetBindings(false);
                cmbRefParty.SelectedValue = account.RefrenceID;
                cmbRefParty.Visible = true;
                txtRefName.Visible = false;
            }
            else
            {
                txtRefName.Visible = true;
                cmbRefParty.Visible = false;
            }

        }

        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            CheckRefType();
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            CheckRefType();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused)
            {
                if (MasterID == 0 && txtName.Text.Length > 0)
                {
                    this.Error("پہلے پارٹی کی قسم منتخب کریں");
                    txtName.Clear();
                    txtName.Select(); return;
                }
                if (txtName.Text.Length > 0)
                {
                    bsAccount1.Filter = $" accountTitle Like '%{txtName.Text.Trim()}%'";
                }
                else
                {
                    bsAccount1.RemoveFilter();
                }
            }
        }

        private void txtRefName_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (var frm = new frmImportAccounts() { StartPosition = FormStartPosition.CenterScreen })
            {
                frm.ShowDialog();
                Refresh();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
