using Dapper;

using DevExpress.XtraPrinting;
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS
{
    public partial class frmMain : Form
    {

        BackgroundWorker wrkr;
        Timer timer;
        public frmMain()
        {
            this.Opacity = 0;
            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;
            this.Shown += FrmMain_Shown;
           this.DoubleBuffered = true;
            General.MultanCityID = General.GetMultanCityID();
            using (var frm = new frmLogin())
            { 
                if(frm.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
            menuStrip1.Visible = General.IsAdmin;
            var lbl = new Label()
            {
                Height = 60, // Set your preferred height
                Font = new Font("jameel noori nastaleeq", 30, FontStyle.Bold), // Use Urdu font
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text = "ملک حاجی صدیق کرناول اینڈ برادرز",
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel2.Height = lbl.Height;
            panel2.Controls.Add(lbl);
            panel2.BackColor = Color.Transparent;
            lbl.BringToFront();



            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            lblFiscalYear.Text = $"مالی سال {this.GetPakistaniFiscalYear()}";
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
        }

       

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("کیا آپ بیک اپ لینا چاہتے ہیں؟","Confirm",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            if (result==DialogResult.Yes)
            {
                using (var db = new db())
                {
                    db.Execute("exec BackupDatabase");
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
            btnItem.Enabled = General.IsAdmin;
            btnCity.Enabled = General.IsAdmin;
            btnBanamVoucher.Enabled = true;
            btnJamaVoucher.Enabled = true;
            btnBeejBardana.Enabled = true;
            btnSale.Enabled = true;
            btnJV.Enabled = true;
            btnLedger.Enabled = General.IsAdmin;
            btnRokar.Enabled = General.IsAdmin;
            btnKhasra.Enabled = General.IsAdmin;
            btnBeejak.Enabled = true;
            bnRecovery.Enabled = General.IsAdmin;
            btnCustomerBill.Enabled = true;
            btnbackup.Enabled = Environment.MachineName.ToLower() == General.dbSystemName.ToLower(); ;
            btnExit.Enabled = true;
            //Buttons Enabling
            btnParty.Visible = General.IsAdmin;
            btnItem.Visible = General.IsAdmin;
            btnCity.Visible = General.IsAdmin;
            btnBanamVoucher.Visible = true;
            btnJamaVoucher.Visible = true;
            btnBeejBardana.Visible = true;
            btnSale.Visible = true;
            btnJV.Visible = true;
            btnLedger.Visible = General.IsAdmin;
            btnRokar.Visible = General.IsAdmin;
            btnKhasra.Visible = General.IsAdmin;
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
            using(var rpt=new rptRokar(DateTime.Now.Date.AddDays(365)))
            {
                rpt.CreateDocument();
            }
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
            var frm = new frmBVNew() { StartPosition = FormStartPosition.CenterScreen };
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
            OpenReportForm(2);
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
            OpenReportForm(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenReportForm(13);
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
        public void LaunchActivator()
        {
            try
            {
                // Path of Updater/Activator in the same folder as Main Application
                string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater", "Updater.exe");

                if (!File.Exists(updaterPath))
                {
                    MessageBox.Show("Activator.exe not found in application folder.");
                    return;
                }

                // Main application's process name (without .exe)
                string mainProcessName = Process.GetCurrentProcess().ProcessName;

                // Main application's current version
                string mainVersion = Application.ProductVersion; // Or your custom version string

                // GitHub Release URL (or any update URL)
                string githubReleaseUrl = "https://api.github.com/repos/GhayyasAwan/MandiPOS_Amir/releases/latest";

                // Pass arguments: "ProcessName Version GitHubURL"
                string args = $"\"{mainProcessName}\" \"{mainVersion}\" \"{githubReleaseUrl}\"";

                // Launch Updater/Activator
                Process.Start(updaterPath, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching Activator: " + ex.Message);
            }
        }
        private void CheckForUpdate(object sender, EventArgs e)
        {
            LaunchActivator();
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
