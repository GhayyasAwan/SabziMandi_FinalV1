using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

using MandiPOS.CLasses;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmAccounts : DevExpress.XtraEditors.XtraForm
    {
        GridView dgv;
        private int _masterID = 0;
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
            txtTitle.Select();
        }
        bool isloading = true;
        public frmAccounts()
        {
            InitializeComponent();
            this.KeyPreview = true;
            cmbRefParty.EditValueChanged += CmbRefParty_EditValueChanged;
            txtCommission.KeyDown += TxtCommission_KeyDown;
            dgv = gridView1;
            dgv.RowClick += Dgv_RowClick; dgv.KeyDown += Dgv_KeyDown;
            txtTitle.KeyDown += TxtTitle_KeyDown;
            Program.UrduInput(true);
            this.MasterIDChanged += (s, e) =>
            {
                if (!isloading)
                {
                    ResetControls();
                }
            };
            this.FormClosing += (s, e) => Program.UrduInput(false);
            this.Load += FrmAccounts_Load;
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
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

        private void DeleteCurrent()
        {
            if (dgv.FocusedRowHandle >= 0)
            {
                try
                {
                    int id = dgv.GetRowCellValue(dgv.FocusedRowHandle, dgv.Columns[0]).toInt();
                    if (id > 0)
                    {
                        if (XtraMessageBox.Show("کیا آپ اس ریکارڈ کو حذف کرنا چاہتے ہیں؟", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DetailAccountService.DeleteDetailAccount(id);
                            ResetControls();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ExcError("While Deleting account...");
                }
            }
        }

        private void EditCurrent()
        {
            account = new DetailAccounts() { MasterID = MasterID };
            if (dgv.FocusedRowHandle >= 0)
            {
                account = DetailAccountService.GetDetailAccountByID(dgv.GetRowCellValue(dgv.FocusedRowHandle, dgv.Columns[0]).toInt());
                if (account == null)
                {
                    account = new DetailAccounts() { MasterID = MasterID };
                }

            }
            BindObject();
            txtTitle.Select();
        }

        private void Dgv_RowClick(object sender, RowClickEventArgs e)
        {
            EditCurrent();
        }

        private void CmbRefParty_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbRefParty.EditValue != null)
            {
                txtRefName.Text = cmbRefParty.Text.ToString();
            }
        }

        private void TxtCommission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlsToObject();
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
        }

        private void ControlsToObject()
        {
            account.AccountCode = txtCode.Text.toInt();
            account.AccountTitle = txtTitle.Text.Trim();
            account.Contact = txtContact.Text.Trim();
            account.CityID = cmbCity.EditValue.toInt();
            account.OpCredit = txtOpCredit.EditValue.toDecimal();
            account.OpDebit = txtOpDebit.EditValue.toDecimal();
            account.Remarks = txtRemarks.Text.Trim();
            account.CreditLimit = txtBalLimit.EditValue.toDecimal();
            account.Commission = txtCommission.EditValue.toDecimal();
            if (radioGroup1.EditValue.toInt() == 0)
            {
                account.RefrenceType = 0;
                account.RefrenceID = null;
                account.RefName = txtRefName.Text.Trim();
            }
            else
            {
                account.RefrenceType = radioGroup1.EditValue.toInt();
                account.RefrenceID = cmbRefParty.EditValue.toInt();
                account.RefName = txtRefName.Text.Trim();
            }
        }

        private void TxtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv.Focus();
            }
        }

        private void FrmAccounts_Load(object sender, EventArgs e)
        {
            PopulateMasterAccounts();
            ResetControls();
            isloading = false;
            DisableEntryPanel(true);
        }

        private void DisableEntryPanel(bool v)
        {
            txtCode.Enabled = txtRefName.Enabled = txtTitle.Enabled = txtContact.Enabled = groupControl1.Enabled = txtOpCredit.Enabled = txtOpDebit.Enabled = txtCommission.Enabled = txtRemarks.Enabled = txtBalLimit.Enabled = v;
        }

        private void PopulateMasterAccounts()
        {
            var master = MasterAccountsService.GetMasterAccounts();
            foreach (var acc in master)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Size = new Size(150, 50),
                    Text = $"{acc.ID} - {acc.AccountTitle}",
                    Tag = acc.ID,
                    Font = new Font("Jameel Noori nastaleeq", 14)
                };
                btn.Click += Btn_Click;
                //if (isFirst)
                //{
                //    btn.PerformClick();
                //    isFirst = false;
                //}
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            MasterID = 0;
            if (sender is SimpleButton btn)
            {
                MasterID = btn.Tag.toInt();
            }
            if (MasterID != 0)
            {
                DisableEntryPanel(false);
            }

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (radioGroup1.EditValue.toInt() == 0)
            {
                txtRefName.Visible = true;
                cmbRefParty.Visible = false;
            }
            else
            {
                bsAccounts2.DataSource = DetailAccountService.GetAccountsViewList(radioGroup1.EditValue.toInt())
; cmbRefParty.Visible = true;
                txtRefName.Visible = false;
            }
        }
        void ResetControls()
        {
            txtCode.Clear();
            txtTitle.Clear();
            txtContact.Clear();
            cmbCity.EditValue = null;
            bsCity.DataSource = SQL.GetCities();
            txtOpCredit.EditValue = 0;
            txtOpDebit.EditValue = 0;
            txtRemarks.Clear();
            txtBalLimit.EditValue = 0;
            txtCommission.EditValue = 0;
            radioGroup1.SelectedIndex = 0;
            Refresh();
        }
        public override void Refresh()
        {
            if (MasterID != 0)
            {
                if (!isloading)
                {
                    bsAccount1.DataSource = DetailAccountService.GetAccountsViewList(MasterID);
                }
                account = new DetailAccounts() { AccountCode = DetailAccountService.GenerateNextAccountCode(MasterID).toInt() };
                BindObject();
                txtTitle.Select();
            }
        }

        private void BindObject()
        {
            txtCode.Text = account.AccountCode.ToString();
            txtTitle.Text = account.AccountTitle;
            txtContact.Text = account.Contact;
            cmbCity.EditValue = account.CityID;
            txtOpCredit.EditValue = account.OpCredit;
            txtOpDebit.EditValue = account.OpDebit;
            txtRemarks.Text = account.Remarks;
            txtBalLimit.EditValue = account.CreditLimit;
            txtCommission.EditValue = account.Commission;
            if (account.RefrenceType.HasValue)
            {
                radioGroup1.SelectedIndex = account.RefrenceType.Value;
                cmbRefParty.EditValue = account.RefrenceID;
            }
            else
            {
                radioGroup1.SelectedIndex = 0;
                txtRefName.Text = account.RefName;
            }

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteRecord(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}