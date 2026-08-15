

using Dapper;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

using MandiPOS.CLasses;
using MandiPOS.GUI;
using MandiPOS.Reports;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS
{
    public partial class frmMain : Form
    {

        BackgroundWorker wrkr;
        Timer timer;
        bool IsLocked = false;
        public frmMain()
        {
            this.Opacity = 0;
            InitializeComponent();
            
            General.Security = tblSecurity.Get;
            this.ControlBox = false;
            General.MultanCityID = General.GetMultanCityID();
            this.FormClosing += FrmMain_FormClosing;
            this.Shown += FrmMain_Shown;
            this.DoubleBuffered = true;
            using (var frm = new frmLogin())
            {
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
            IsLocked = General.CheckIsApplicationLocked();
            menuStrip1.Visible = General.IsAdmin;
            l1.BackColor = l2.BackColor = lblTime.BackColor = lblFiscalYear.BackColor = l3.BackColor = Color.Transparent;


            //var lbl = new Label()
            //{
            //    Height = 120, // Set your preferred height
            //    Font = new Font("jameel noori nastaleeq", 50, FontStyle.Bold), // Use Urdu font
            //    ForeColor = Color.Black,
            //    BackColor = Color.Transparent,
            //    AutoSize = false,
            //    Dock = DockStyle.Top,
            //    Text = line1,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            // panel2.Height = lbl.Height;
            //panel2.Controls.Add(lbl);
            //var lbl2 = new Label()
            //{
            //    Height = 120, // Set your preferred height
            //    Font = new Font("jameel noori nastaleeq", 50, FontStyle.Bold), // Use Urdu font
            //    ForeColor = Color.Black,
            //    BackColor = Color.Transparent,
            //    AutoSize = false,
            //    Dock = DockStyle.Top,
            //    Text = line2,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            //// panel2.Height = lbl.Height;
            //panel2.Controls.Add(lbl2);
            //var lbl3 = new Label()
            //{
            //    Height = 120, // Set your preferred height
            //    Font = new Font("jameel noori nastaleeq", 50, FontStyle.Bold), // Use Urdu font
            //    ForeColor = Color.Black,
            //    BackColor = Color.Transparent,
            //    AutoSize = false,
            //    Dock = DockStyle.Top,
            //    Text = line3,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            //// panel2.Height = lbl.Height;
            //panel2.Controls.Add(txt);

            //lbl.BringToFront();



            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            lblFiscalYear.Text = $"مالی سال {DateTime.Now.Year}";
            this.Opacity = 0;
            SetBGImage();

            wrkr = new BackgroundWorker();
            wrkr.DoWork += Wrkr_DoWork;

            this.panel1.BackColor = Color.Transparent;
            this.KeyPreview = true;
            this.KeyDown += FrmMain_KeyDown;
            this.FormClosing += FrmMain_FormClosing1;
            this.Activated += FrmMain_Activated;
            this.Load += FrmMain_Load;
            this.Resize += FrmMain_Resize;
            SetButtonsvisibility();
            CheckForSoftwareLocked();
        }
        private void CheckForSoftwareLocked()
        {
            btnParty.Enabled = !IsLocked;
            btnBanamVoucher.Enabled = !IsLocked;
            btnJamaVoucher.Enabled = !IsLocked;
            btnBeejVoucher.Enabled = !IsLocked;
            btnBardanaVoucher.Enabled = !IsLocked;
            btnJV.Enabled=btnSale.Enabled= !IsLocked;
            btnbardanaAamad.Enabled = btnBardanaNakas.Enabled = !IsLocked;
            mnu_Utilities.Enabled = mnu_COA.Enabled = mnu_Security.Enabled = !IsLocked;
            masterAccountsToolStripMenuItem.Enabled = !IsLocked;
            detailAccountsToolStripMenuItem.Enabled = !IsLocked;
            defaultAccountsToolStripMenuItem.Enabled = !IsLocked;
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Environment.MachineName==General.dbSystemName)
            {
                var result = MessageBox.Show("کیا آپ بیک اپ لینا چاہتے ہیں؟", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string dir = new db().ExecuteScalar<string>($"Select ConfigValue From tblConfigs Where ConfigName like 'BackupDirectory';");
                        Directory.CreateDirectory(dir);
                        using (var db = new db())
                        {
                            db.Execute("exec BackupDatabase");
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ExcError();
                    }
                } 
            }
        }

        private void FrmMain_Shown1(object sender, EventArgs e)
        {

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //_pendingRelease = await GitHubUpdater.CheckForNewReleaseAsync(
            //"GhayyasAwan", "MandiPOS");
            //if (_pendingRelease != null)
            //{
            //    // Make the “Download Updates…” link visible
            //    toolStripStatusLabelUpdate.Visible = true;
            //}
            this.Opacity = 100;
        }

        private void SetButtonsvisibility()
        {
            btnParty.Enabled = General.IsAdmin;
            //btnItem.Enabled = General.IsAdmin;
            //btnCity.Enabled = General.IsAdmin;
            btnBanamVoucher.Enabled = true;
            btnJamaVoucher.Enabled = true;
            btnBeejVoucher.Enabled = General.IsAdmin;
            btnSale.Enabled = true;
            btnJV.Enabled = General.IsAdmin;
            btnLedger.Enabled = General.IsAdmin;
            btnRokar.Enabled = General.IsAdmin;
            btnKhasra.Enabled = true;
            btnBeejak.Enabled = true;
            bnRecovery.Enabled = General.IsAdmin;
            // btnSale is inside flowLayoutPanel1
            flowLayoutPanel1.SetFlowBreak(btnSale, General.IsAdmin);

            btnCustomerBill.Enabled = true;
            btnbackup.Enabled = Environment.MachineName.ToLower() == General.dbSystemName.ToLower(); ;
            btnExit.Enabled = true;
            //Buttons Enabling
            btnParty.Visible = General.IsAdmin;
            //btnItem.Visible = General.IsAdmin;
            //btnCity.Visible = General.IsAdmin;
            btnBanamVoucher.Visible = true;
            btnJamaVoucher.Visible = true;
            btnBeejVoucher.Visible = General.IsAdmin;
            btnSale.Visible = true;
            btnJV.Visible = General.IsAdmin;
            btnLedger.Visible = General.IsAdmin;
            btnRokar.Visible = General.IsAdmin;
            btnKhasra.Visible = true;
            btnBeejak.Visible = true;
            bnRecovery.Visible = General.IsAdmin;
            btnCustomerBill.Visible = true;
            btnbackup.Visible = Environment.MachineName.ToLower() == General.dbSystemName.ToLower() && General.IsAdmin;
            btnExit.Visible = true;
        }

        private void SetBGImage()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer, true);
            this.BackgroundImage = Program.AppBackground;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }
        private void Wrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            SQL.SetDefaultAccount();
            //SaleService.RepostSales();
            //using (var rpt = new rptRokar(DateTime.Now.Date.AddDays(365)))
            //{
            //    rpt.CreateDocument();
            //}
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!lblTime.Visible)
            {
                lblTime.Show();
            }
            lblTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {

        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {

            //for (int i = 0; i <= 10; i++)
            //{
            //    this.Opacity = i / 10.0;
            //    await Task.Delay(30);
            //}

            wrkr.RunWorkerAsync();

        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                Program.UrduInput(false);
            }
        }

        private void FrmMain_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Program.UrduInput(false);
        }
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D1)
            {
                //Open City Form
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var handle = SplashScreenManager.ShowOverlayForm(this))
            {
                using (var frm = new frmItems())
                {
                    frm.IconOptions.Icon = this.Icon;
                    frm.Shown += (s, x) =>
                    {
                        SplashScreenManager.CloseOverlayForm(handle);
                    };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var handle = SplashScreenManager.ShowOverlayForm(this))
            {
                using (var frm = new frmCity())
                {
                    frm.IconOptions.Icon = this.Icon;
                    frm.Shown += (s, x) =>
                    {
                        SplashScreenManager.CloseOverlayForm(handle);
                    };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            var frm = new frmAccounts();
            frm.IconOptions.Icon = this.Icon;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();

        }

        private void masterAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var handle = SplashScreenManager.ShowOverlayForm(this))
            {
                using (var frm = new frmMasterAccounts())
                {
                    frm.IconOptions.Icon = this.Icon;
                    frm.Shown += (s, x) =>
                    {
                        SplashScreenManager.CloseOverlayForm(handle);
                    };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);
                }
            }
        }

        frmAccounts frmAccounts;
        frmVoucher frmVoucher;
        private void detailAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var handle = SplashScreenManager.ShowOverlayForm(this))
            {
                if (frmAccounts == null)
                {
                    frmAccounts.IconOptions.Icon = this.Icon;
                    frmAccounts = new frmAccounts();
                    frmAccounts.Show();
                    frmAccounts.BringToFront();
                }
                else
                {
                    frmAccounts.BringToFront();
                }
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            using (var handle = SplashScreenManager.ShowOverlayForm(this))
            {
                if (frmVoucher == null)
                {
                    frmVoucher.IconOptions.Icon = this.Icon;
                    frmVoucher = new frmVoucher(0);
                    frmVoucher.Show();
                }
                else
                {
                    frmVoucher.BringToFront();
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            using (new crsr())
            {
                var frm = new frmBardanaVoucher();
                frm.Icon = this.Icon;
                var f = Application.OpenForms[frm.Name];
                if (f != null) { f.BringToFront(); }
                else
                {
                    frm.Show();
                }
            }
        }

        private void OpenSaleForm(object sender, EventArgs e)
        {
            var frm = new frmSale() { Text = "Sale", WindowState = FormWindowState.Maximized, KeyPreview = true };
            var f = Application.OpenForms[frm.Name];
            if (f != null)
            {
                f.BringToFront();
            }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            using (new crsr())
            {
                var frm = new frmJournalVoucher();
                var f = Application.OpenForms[frm.Name];
                if (f != null)
                {
                    f.BringToFront();
                }
                else
                {
                    frm.Icon = this.Icon;
                    frm.ShowDialog(this);
                }
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void OpenCityForm()
        {
            var frm = new frmCityNew();
            var f = Application.OpenForms[frm.Name];
            if (f != null)
            {
                f.BringToFront();
            }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            var frm = new frmAccountsNew();
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else

            {
                frm.Icon = this.Icon;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenItemsForm();
        }

        private void OpenItemsForm()
        {
            var frm = new frmItemsNew();
            var f = Application.OpenForms[frm.Name];
            if (f != null)
            {
                f.BringToFront();
            }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenCityForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenAccountForm();
        }

        private void OpenAccountForm()
        {
            var frm = new frmAccountsNew2();
            var f = Application.OpenForms[frm.Name];
            if (f != null)
            { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new frmVoucherNew(0) { Name = Name + "_0" };
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var frm = new frmSaleNew();
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var frm = new frmVoucherNew(1) { Name = Name + "_1" };
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var frm = new frmJVNew();
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenBardanaVoucher();

        }

        private void OpenBardanaVoucher(int type = 3)
        {
            var frm = new frmBVNew(type) { StartPosition = FormStartPosition.CenterScreen };
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void defaultAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConfigs())
            {
                frm.ShowDialog();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenReportForm(1);
        }

        private void OpenReportForm(int v)
        {
            var frm = new frmReportsNew(v);
            if (Application.OpenForms[frm.Name] != null)
            {
                Application.OpenForms[frm.Name].BringToFront();
            }
            else
            {
                frm.Icon = this.Icon;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBackup() { StartPosition = FormStartPosition.CenterScreen })
            {
                frm.ShowDialog(this);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (new waitForm())
            {
                var report = new rptRokar(DateTime.Now.Date);
                ShowReport(report, 1.4f);
            }
        }
        private void ShowReport(XtraReport rpt, float zoom = 1.5f)
        {
            if (rpt == null) return;
            var frm = new XtraForm1(rpt, zoom);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(); frm.BringToFront();
            return;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBackup() { StartPosition = FormStartPosition.CenterScreen })
            {
                frm.ShowDialog(this);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenReportForm(6);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var frm = new frmKhasraSummary(DateTime.Now.Date);
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (new waitForm())
            {
                var rpt = new rptCustomerRecovery(DateTime.Now.Date);

                rpt.CreateDocument();
                ShowReport(rpt);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenReportForm(15);
        }

        private void changeWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frWPChanger()
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                MinimizeBox = false,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmUsers() { StartPosition = FormStartPosition.CenterScreen })
            {
                frm.ShowDialog(this);
            }
        }
        private GitHubRelease _pendingRelease;
        private static async Task DownloadFileWithProgressAsync(
    string downloadUrl,
    string destinationPath,
    IProgress<int> progress)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(
                    downloadUrl,
                    HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var receivedBytes = 0L;
                    var buffer = new byte[8192];

                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var fileStream = new FileStream(
                            destinationPath,
                            FileMode.Create,
                            FileAccess.Write,
                            FileShare.None,
                            buffer.Length,
                            useAsync: true))
                        {

                            int bytesRead;
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                receivedBytes += bytesRead;

                                if (totalBytes > 0)
                                {
                                    int percent = (int)((receivedBytes * 100L) / totalBytes);
                                    progress.Report(percent);
                                }
                            }

                            // Ensure progress bar reaches 100%
                            progress.Report(100);
                        }
                    }

                }

            }
            // GitHub requires a User-Agent for API calls; downloads are direct so not strictly needed here



        }


        private async void DownlaodUpdates(object sender, EventArgs e)
        {
            // Hide link, show progress
            toolStripStatusLabelUpdate.Visible = false;
            toolStripProgressBarDownload.Visible = true;
            toolStripProgressBarDownload.Value = 0;

            // Assume first asset is your installer
            var asset = _pendingRelease.Assets[0];
            var version = _pendingRelease.TagName.TrimStart('v', 'V');
            var ext = Path.GetExtension(asset.Name);
            var fileName = $"{version}{ext}";
            var downloadPath = Path.Combine(Application.StartupPath, fileName);
            try
            {
                await DownloadFileWithProgressAsync(
                    asset.BrowserDownloadUrl,
                    downloadPath,
                    new Progress<int>(percent =>
                    {
                        toolStripProgressBarDownload.Value = percent;
                    })
                );

                // Launch the installer when done
                System.Diagnostics.Process.Start(downloadPath);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Download failed: {ex.Message}",
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Restore link so user can retry
                toolStripStatusLabelUpdate.Visible = true;
                toolStripProgressBarDownload.Visible = false;
            }

        }

        private void شہراندراجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCityForm();
        }

        private void اشیاءاندراجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenItemsForm();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenBardanaVoucher(5);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchActivator();
        }
        public void LaunchActivator()
        {
            try
            {
                // Path of Updater/Activator in the same folder as Main Application
                string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,  "UpdaterV2.exe");

                string versionJsonUrl = "https://raw.githubusercontent.com/GhayyasAwan/MandiPOS_Muqaddam/main/update/version.json";
                Process currentProcess = Process.GetCurrentProcess();
                string processName = currentProcess.ProcessName;
                string arguments = $"\"{versionJsonUrl}\" \"{processName}\" \"{General.UserName}\"";
                Process.Start(updaterPath, arguments);

                //if (!System.IO.File.Exists(updaterPath))
                //{
                //    MessageBox.Show("Activator.exe not found in application folder.");
                //    return;
                //}

                //// Main application's process name (without .exe)
                //string mainProcessName = Process.GetCurrentProcess().ProcessName;

                //// Main application's current version
                //string mainVersion = Application.ProductVersion; // Or your custom version string

                //// GitHub Release URL (or any update URL)
                //string githubReleaseUrl = "https://api.github.com/repos/GhayyasAwan/MandiPOS_Muqaddam/releases/latest";

                //// Pass arguments: "ProcessName Version GitHubURL"
                //string args = $"\"{mainProcessName}\" \"{mainVersion}\" \"{githubReleaseUrl}\"";

                //// Launch Updater/Activator
                //Process.Start(updaterPath, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching Activator: " + ex.Message);
            }
        }

        private void repostVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRepostVouchers())
            {
                frm.ShowDialog(this);
            }
        }

        private void بیوپاریڈوبتکھاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new VendorDobatKhatay())
            {
                frm.ShowIcon = frm.ShowInTaskbar = false;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void securityPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSecurityPasswords())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowIcon = frm.ShowInTaskbar = false;
                frm.ShowDialog(this);
            }
        }

        private void گاہکڈوبتکھاتہToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new CustomerDobatKhatay())
            {
                frm.ShowIcon = frm.ShowInTaskbar = false;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSecurityPasswords())
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = frm.ShowIcon = false;
                frm.Text = "Change Passwords";
                frm.ShowDialog(this);
                General.Security = tblSecurity.Get;
            }
        }

        private void StockInVoucher(object sender, EventArgs e)
        {
            var frm = new frmBVNew2(0) { StartPosition = FormStartPosition.CenterScreen };
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void StockOutVoucher(object sender, EventArgs e)
        {
            var frm = new frmBVNew2(1) { StartPosition = FormStartPosition.CenterScreen };
            var f = Application.OpenForms[frm.Name];
            if (f != null) { f.BringToFront(); }
            else
            {
                frm.Icon = this.Icon;
                frm.Show();
            }
        }

        private void باردانہرپورٹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBardanaReport())
            {
                frm.ShowDialog(this);
            }
        }
    }
    public class crsr : IDisposable
    {
        public crsr()
        {
            Cursor.Current = Cursors.WaitCursor;
        }
        public void Dispose()
        {
            Cursor.Current = Cursors.Arrow;
        }
    }
}
