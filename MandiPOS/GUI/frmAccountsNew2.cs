using MandiPOS.CLasses;

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmAccountsNew2 : Form
    {
        public int MasterID = 0;
        clsResize objR;
        bool isloading = true;
        DetailAccounts account = new DetailAccounts();
        public frmAccountsNew2()
        {
            InitializeComponent();
            RegisterEnter();
            RegisterFocus();
            this.KeyPreview = true;
            this.KeyDown += ((s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    SaveRecord();
                }
            });
            PopulateMasterAccounts();
            gridEX1.RowDoubleClick += GridEX1_RowDoubleClick;
            this.Resize += FrmAccountsNew2_Resize;
            this.Load += FrmAccountsNew2_Load;
            txtName.TextChanged += TxtName_TextChanged;
            objR = new clsResize(this);

        }

        private void GridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (gridEX1.CurrentRow != null)
            {
                int id = gridEX1.CurrentRow.Cells["ID"].Value.toInt();
                account = DetailAccountService.GetDetailAccountByID(id);
                BindObject();
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused && txtName.TextLength > 0)
            {
                bsAccount1.Filter = $"AccountTitle LIKE '%{txtName.Text}%'";
            }
            else
            {
                bsAccount1.RemoveFilter();
            }
        }

        private void RegisterEnter()
        {
            txtCode.EnterToNext();
            txtName.EnterToNext();
            txtContact.EnterToNext();
            cmbCity.EnterToNext();
            txtDebit.EnterToNext();
            txtCredit.KeyDown += ((sender, e) =>
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
            account.CityID = cmbCity.SelectedValue.toInt();
            account.OpCredit = txtCredit.Text.toDecimal();
            account.OpDebit = txtDebit.Text.toDecimal();
            if (!EntryValid())
            {
                return;
            }
            if (account.ID == 0)
            {
                account.MasterID = MasterID;
                DetailAccountService.SaveDetailAccount(account);
                Refresh(); this.Info("ریکارڈ محفوظ ہوگیا۔");
            }
            else
            {
                DetailAccountService.SaveDetailAccount(account);
                Refresh(); this.Info("ریکارڈ اپڈیٹ ہوگیا۔");
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
                    bsAccount1.DataSource = DetailAccountService.GetAccountsViewList(MasterID).OrderByDescending(x => x.AccountCode).ToDataTable();
                }
                bsAccount1.RemoveFilter();
                gridEX1.AutoSizeColumns();
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
            cmbCity.SelectedValue = account.CityID;
            if (!account.RefrenceType.HasValue) { account.RefrenceType = 0; }
            txtName.Select(); txtName.SelectAll();
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
            foreach (var acc in master)
            {
                Button btn = new Button()
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Name = $"btn{acc.ID}",
                    Text = $"{acc.ID} - {acc.AccountTitle}",
                    Tag = acc.ID,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0, MouseOverBackColor = SystemColors.Highlight, MouseDownBackColor = SystemColors.Highlight },
                    Font = new Font("Jameel Noori nastaleeq", 14),
                    //VisualStyleManager = this.visualStyleManager1,
                    RightToLeft = RightToLeft.Yes,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                if (acc.ID == 4 || acc.ID == 7)
                {
                    btn.BackColor = Color.ForestGreen;
                    btn.ForeColor = Color.White;
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
                foreach (Button b in flowLayoutPanel1.Controls)
                {
                    if (b.Name == btn.Name)
                    {
                        b.BackColor = SystemColors.Highlight;
                        b.ForeColor = Color.White;
                    }
                    else
                    {
                        if (b.Tag.toInt() == 4 || b.Tag.toInt() == 7)
                        {
                            b.BackColor = Color.ForestGreen;
                            b.ForeColor = Color.White;
                        }
                        else
                        {
                            b.BackColor = SystemColors.Control;
                            b.ForeColor = Color.Black;
                        }
                    }
                }
            }
            if (MasterID != 4 && MasterID != 7)
            {
                Refresh();
            }
            else
            {
                bsAccount1.DataSource = null;
                bsAccount1.ResetBindings(false);
                bsAccount1.RemoveFilter();
                using (var frm = new frmAccountsNew(MasterID))
                {
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }
    }
}
