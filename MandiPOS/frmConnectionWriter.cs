using MandiPOS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configurations
{
    public partial class frmConnectionWriter : Form
    {
        public frmConnectionWriter(string FilePath)
        {
            InitializeComponent();
            this.Load += FrmConnectionWriter_Load;
            _filepath = FilePath;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        if (instanceName.ToLower() != "MSSQLSERVER".ToLower())
                        {
                            txtServerName.Items.Add(Environment.MachineName + @"\" + instanceName);
                        }
                        else
                        {
                            txtServerName.Items.Add(Environment.MachineName);
                        }
                    }
                }
            }
            if (txtServerName.Items.Count > 0)
            {
                txtServerName.SelectedIndex = 0;
            }
        }
        string _filepath = string.Empty;
        private void FrmConnectionWriter_Load(object sender, EventArgs e)
        {
            //txtServerName.Text = Environment.MachineName;
        }

        private void cbIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIntegratedSecurity.Checked)
            {
                txtUserName.Enabled = txtPassword.Enabled = false;
                txtPassword.Clear(); txtUserName.Clear();
            }
            else
            {
                txtUserName.Enabled = txtPassword.Enabled = true;
            }
        }
        SqlConnectionStringBuilder bldr;
        bool Isconnection
        {
            get
            {
                using (SqlConnection cn = new SqlConnection(bldr.ConnectionString))
                {
                    try
                    {
                        cn.Open(); cn.Close(); return true;
                    }
                    catch (Exception ex)
                    {
                        return ex.ExcError();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MakeConnectionString();
            if (Isconnection)
            {
                this.Info("Connection Succeeded.");
            }
        }

        private void MakeConnectionString()
        {
            bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = txtServerName.Text.Trim();
            bldr.IntegratedSecurity = cbIntegratedSecurity.Checked;
            bldr.Encrypt = cbEncrypt.Checked;
            bldr.TrustServerCertificate = cbTrust.Checked;
            if (!cbIntegratedSecurity.Checked)
            {
                bldr.UserID = txtUserName.Text.Trim();
                bldr.Password = txtPassword.Text.Trim();
            }
            if (cbDatabase.SelectedIndex != -1 && cbDatabase.Text.Trim() != string.Empty)
            {
                bldr.InitialCatalog = cbDatabase.Text.Trim();
            }
        }

        private void cbDatabase_DropDown(object sender, EventArgs e)
        {
            MakeConnectionString();
            if (Isconnection)
            {
                GetDatabasesList();
            }
        }

        private void GetDatabasesList()
        {

            string sql = "SELECT name from sys.databases Where name not in ('master','tempdb','model','msdb')";
            cbDatabase.Items.Clear();
            using (var db = new SqlConnection(bldr.ConnectionString))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand(sql, db))
                {
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable(); dt.Load(reader);
                    if (dt.Rows.Count>0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            cbDatabase.Items.Add(r[0].ToString());
                        }
                    }
                }
            }
            if (cbDatabase.Items.Count>0)
            {
                cbDatabase.SelectedIndex = 0; 
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cbDatabase.Text.Trim() == string.Empty)
            {
                this.Error("Please Select Database.");
                return;
            }
            MakeConnectionString();
            if (Isconnection)
            {
                File.WriteAllText(_filepath, bldr.ConnectionString);
                //  AppSetting setting = new AppSetting();
                // if (setting.SaveConnectionString("ConnectionString", bldr.ConnectionString))
                // {
                this.DialogResult = DialogResult.OK;
                // Application.Restart();
                // }
            }
        }

        private void frmConnectionWriter_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
