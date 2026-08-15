using Dapper;

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using static MandiPOS.SQL;

namespace MandiPOS.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Shown += FrmLogin_Shown;
            LoadExeIcon();
            editBox1.RegisterFocus(false);
            editBox2.RegisterFocus(false);
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                var user = new db().GetList<CLasses.tblUsers>().FirstOrDefault();
                if (user != null)
                {
                    editBox1.Text = user.UserName; // Default username for testing
                    editBox2.Text = user.UserPassword; // Default password for testing
                }

            }
        }

        private void LoadExeIcon()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;
            Icon appIcon = Icon.ExtractAssociatedIcon(exePath);

            if (appIcon != null)
            {
                this.Icon = appIcon; // Sets the form's icon
                                     // Optional: assign to a PictureBox if you want to display it
                                     // pictureBox1.Image = appIcon.ToBitmap();
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string username = editBox1.Text.Trim();
            string password = editBox2.Text.Trim();
            var users = new db().GetList<CLasses.tblUsers>().ToList();
            if (users.Any())
            {
                var user = users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.UserPassword == password);
                if (user != null)
                {
                    General.IsAdmin = user.IsAdmin;
                    General.UserName = user.UserName;
                    General.CurrentUserID = user.UserID;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.Error("Invalid username or password. Please try again.");
                    return;
                }
            }
            else
            {
                this.Error("Unable to login, no users found. Please create a user first.");
                return;
            }
        }

        private void editBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(editBox1.Text) && e.KeyCode == Keys.Enter)
            {
                editBox2.Focus();
            }
        }

        private void editBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(editBox2.Text) && e.KeyCode == Keys.Enter)
            {
                uiButton1.PerformClick(); // Simulate button click to login
            }
        }
    }
}
