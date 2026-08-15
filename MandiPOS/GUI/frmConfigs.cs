
using Dapper;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;
using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmConfigs : Form
    {
        public frmConfigs()
        {
            InitializeComponent();
            this.Load += FrmConfigs_Load;
            netpaid.RegisterFocus(false);
            netpaid.KeyDown += checkKey;
            commission.KeyDown += checkKey;
            mazdoori.KeyDown += checkKey;
            munshiana.KeyDown += checkKey;
            karaya.KeyDown += checkKey;
            store.KeyDown += checkKey;
            pending.KeyDown += checkKey;
            laga.KeyDown += checkKey;
            netsale.KeyDown += checkKey;

        }

        Control focused;
        private void checkKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                ClearControl(sender as Control);
            }
            if (e.KeyCode == Keys.Enter)
            {
                (sender as Control).Parent.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                focused = sender as Control;
                GetAccountHelper();
            }
        }

        private void GetAccountHelper()
        {
            using (frmAccountsHelp frm = new frmAccountsHelp())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.row != null)
                    {
                        SetValues(frm.row);
                    }
                }
            }
        }

        private void SetValues(GridEXRow row)
        {
            var id = row.Cells["ID"].Value;
            var title = row.Cells["AccountTitle"].Value.ToString();
            switch (focused.Name.ToLower())
            {
                case "netpaid":
                    netpaid.Text = title; netpaidID.Text = id.ToString(); break;
                case "commission":
                    commission.Text = title; commissionID.Text = id.ToString(); break;
                case "mazdoori":
                    mazdoori.Text = title; mazdooriID.Text = id.ToString(); break;
                case "munshiana":
                    munshiana.Text = title; munshianaID.Text = id.ToString(); break;
                case "karaya":
                    karaya.Text = title; karayaID.Text = id.ToString(); break;
                case "store":
                    store.Text = title; storeID.Text = id.ToString(); break;
                case "pending":
                    pending.Text = title; pendingID.Text = id.ToString(); break;
                case "laga":
                    laga.Text = title; lagaID.Text = id.ToString(); break;
                case "netsale":
                    netsale.Text = title; netsaleid.Text = id.ToString(); break;
            }
        }

        private void ClearControl(Control control)
        {
            switch (control.Name.ToLower())
            {
                case "netpaid":
                    netpaid.Clear(); netpaidID.Clear(); break;
                case "commission":
                    commission.Clear(); commissionID.Clear(); break;
                case "mazdoori":
                    mazdoori.Clear(); mazdooriID.Clear(); break;
                case "munshiana":
                    munshiana.Clear(); munshianaID.Clear(); break;
                case "karaya":
                    karaya.Clear(); karayaID.Clear(); break;
                case "store":
                    store.Clear(); storeID.Clear(); break;
                case "pending":
                    pending.Clear(); pendingID.Clear(); break;
                case "laga":
                    laga.Clear(); lagaID.Clear(); break;
            }
        }

        private void FrmConfigs_Load(object sender, EventArgs e)
        {
            InitiateForm();
        }

        private void InitiateForm()
        {
            netpaid.RegisterFocus(true);
            commission.RegisterFocus(true);
            mazdoori.RegisterFocus(true);
            munshiana.RegisterFocus(true);
            karaya.RegisterFocus(true);
            store.RegisterFocus(true);
            pending.RegisterFocus(true);
            laga.RegisterFocus(true);
            netsale.RegisterFocus(true);


            var records = new db().GetList<tblConfigs>();
            if (records.Any())
            {
                var accounts = DetailAccountService.GetAccountsViewList().ToList();
                foreach (tblConfigs record in records)
                {
                    int id = record.ConfigValue.toInt();
                    var acc = accounts.Where(x => x.ID == id).FirstOrDefault();
                    if (acc == null)
                    {
                        continue;
                    }
                    string title = acc.AccountTitle;
                    switch (record.ConfigName.ToLower())
                    {
                        case "netpaid":
                            netpaid.Text = title; netpaidID.Text = id.ToString(); break;
                        case "commission":
                            commission.Text = title; commissionID.Text = id.ToString(); break;
                        case "mazdoori":
                            mazdoori.Text = title; mazdooriID.Text = id.ToString(); break;
                        case "munshiana":
                            munshiana.Text = title; munshianaID.Text = id.ToString(); break;
                        case "karaya":
                            karaya.Text = title; karayaID.Text = id.ToString(); break;
                        case "store":
                            store.Text = title; storeID.Text = id.ToString(); break;
                        case "pending":
                            pending.Text = title; pendingID.Text = id.ToString(); break;
                        case "laga":
                            laga.Text = title; lagaID.Text = id.ToString(); break;
                        case "netsale":
                            netsale.Text = title; netsaleid.Text = id.ToString(); break;
                    }
                }
            }
            netpaid.Select();
        }

        DataTable dtAccounts = new DataTable();
        List<MultiColumnCombo> comboBoxes;
        private void GetOtherAccounts()
        {

            dtAccounts = DetailAccountService.PartyAccounts().ToDataTable();
            foreach (MultiColumnCombo cmb in comboBoxes)
            {

                cmb.DataSource = dtAccounts;
                cmb.DisplayMember = "AccountTitle";
                cmb.ValueMember = "ID";
                cmb.SelectedIndex = -1;
            }

        }

        //private void GetCashAccounts()
        //{
        //    var cashAccounts = DetailAccountService.BankCashAccounts().ToDataTable();
        //    store.DataSource = cashAccounts;
        //    store.DisplayMember = "AccountTitle";
        //    store.ValueMember = "ID";
        //}

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sql = "";
            List<tblConfigs> configs = new List<tblConfigs>();
            configs.Add(new tblConfigs() { ConfigName = "netpaid", ConfigValue = netpaidID.Text });
            configs.Add(new tblConfigs() { ConfigName = "commission", ConfigValue = commissionID.Text });
            configs.Add(new tblConfigs() { ConfigName = "mazdoori", ConfigValue = mazdooriID.Text });
            configs.Add(new tblConfigs() { ConfigName = "munshiana", ConfigValue = munshianaID.Text });
            configs.Add(new tblConfigs() { ConfigName = "karaya", ConfigValue = karayaID.Text });
            configs.Add(new tblConfigs() { ConfigName = "store", ConfigValue = storeID.Text });
            configs.Add(new tblConfigs() { ConfigName = "pending", ConfigValue = pendingID.Text });
            configs.Add(new tblConfigs() { ConfigName = "laga", ConfigValue = lagaID.Text });
            configs.Add(new tblConfigs() { ConfigName = "netsale", ConfigValue = netsaleid.Text });
            foreach (tblConfigs c in configs)
            {
                sql += $"Delete from tblConfigs Where ConfigName like '{c.ConfigName}';\r\n\t";
                sql += $"Insert into tblconfigs (ConfigName,ConfigValue) Values ('{c.ConfigName}','{c.ConfigValue}');\r\n\t";
            }
            if (!string.IsNullOrEmpty(sql))
            {
                using (var connection = new db())
                {
                    using (var trx = connection.BeginTransaction())
                    {
                        try
                        {
                            connection.Execute(sql, transaction: trx);
                            trx.Commit();
                            SQL.SetDefaultAccount();
                            InitiateForm();
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();
                            ex.ExcError("Saving Configuration....");
                        }
                    }
                }
            }


        }
    }
}
