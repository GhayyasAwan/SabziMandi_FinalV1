using DevExpress.Emf;
using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmAccountsNew2 : Form
    {
        public int MasterID=0;
        clsResize objR;
        bool isloading = true;
        DetailAccounts account = new DetailAccounts();
        public frmAccountsNew2()
        {
            InitializeComponent();
            gridEX1.RowDoubleClick += GridEX1_RowDoubleClick;  
            RegisterEnter();
            RegisterFocus();
            PopulateMasterAccounts();
            this.Resize += FrmAccountsNew2_Resize;
            this.Load += FrmAccountsNew2_Load;
            objR = new clsResize(this);
            
        }

        private void GridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if(gridEX1.RowCount>0 && gridEX1.CurrentRow!=null)
            {
                int id = gridEX1.CurrentRow.Cells["ID"].Value.toInt();
                account = DetailAccountService.GetDetailAccountByID(id);
                BindObject();
            }
        }

        private void RegisterEnter()
        {
            txtCode.EnterToNext();
            txtName.EnterToNext();
            txtContact.EnterToNext();
            cmbCity.EnterToNext();
            txtDebit.EnterToNext();
            txtOldAcc.EnterToNext();
            txtCredit.KeyDown+=((sender, e) =>
            {
                if (e.EnterKey())
                {
                    SaveRecord();
                }
            });
        }

        private void SaveRecord()
        {
            account.AccountCode = txtCode.Text.toInt();
            account.AccountTitle = txtName.Text;
            account.Contact = txtContact.Text;
            account.IsActive = uiCheckBox1.Checked;
            account.CityID = cmbCity.SelectedValue.toInt();
            account.OpCredit = txtCredit.Text.toDecimal();
            account.OpDebit = txtDebit.Text.toDecimal();
            account.OldAccountCode = txtOldAcc.Text.Trim().toInt();
            if (!EntryValid())
            {
                return;
            }
            if (account.ID == 0)
            {
                account.MasterID = MasterID;
                DetailAccountService.SaveDetailAccount(account);
                Refresh();
            }
            else
            {
                DetailAccountService.SaveDetailAccount(account);
                Refresh();
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
            return true;
        }
        private void RegisterFocus()
        {
            txtCode.RegisterFocus(true);
            txtName.RegisterFocus(true);
            cmbCity.RegisterFocus(true);
            txtContact.RegisterFocus(false);
            txtCredit.RegisterFocus(false);
            txtDebit.RegisterFocus(false);
        }
        public override void Refresh()
        {
            if (MasterID != 0)
            {
                bsCity.DataSource = SQL.GetCities();
                bsCity.ResetBindings(false);
                if (!isloading)
                {
                    bsAccount1.DataSource = DetailAccountService.GetAccountsViewList(MasterID,true).OrderByDescending(x=>x.AccountCode).ToDataTable();
                }
                bsAccount1.RemoveFilter();
                account = new DetailAccounts() { AccountCode = DetailAccountService.GenerateNextAccountCode(MasterID).toInt() };
                BindObject();

            }
        }
        private void BindObject()
        {
            txtCode.Text = account.AccountCode.ToString();
            txtName.Text = account.AccountTitle;
            uiCheckBox1.Checked=account.IsActive;   
            txtContact.Text = account.Contact;
            txtOldAcc.Text = account.OldAccountCode.ToString();
            txtCredit.Text = (account.OpCredit).ToString("0.##");
            txtDebit.Text = (account.OpDebit).ToString("0.##");
            cmbCity.SelectedValue = account.CityID;
            if (!account.RefrenceType.HasValue) { account.RefrenceType = 0; }
            txtName.Select();
        }
        private void FrmAccountsNew2_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            { 
                WindowState = FormWindowState.Maximized;
            }
            objR._resize();
        }

        private void FrmAccountsNew2_Load(object sender, EventArgs e)
        {
            objR._get_initial_size();
            this.WindowState = FormWindowState.Maximized;
            isloading = false;
        }

        private void PopulateMasterAccounts()
        {
            var master = MasterAccountsService.GetMasterAccounts();
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
                if (acc.ID == 4)
                {
                    btn.ForeColor = Color.White; btn.BackColor = Color.ForestGreen;
                }
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
            if (sender is Button btn)
            {
                MasterID = btn.Tag.toInt();
            }
            if (MasterID != 4)
            {
                Refresh();
            }
            else
            {
                bsAccount1.DataSource = null;
                bsAccount1.ResetBindings(false);
                bsAccount1.RemoveFilter();
                using (var frm = new frmAccountsNew())
                {
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Focused)
            {
                bsAccount1.Filter = $"AccountTitle Like '%{txtName.Text.Trim()}%'";
                bsAccount1.ResetBindings(false);
            }
        }
    }
}
