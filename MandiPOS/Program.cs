using DbUp;
using DbUp.ScriptProviders;

using DevExpress.XtraWaitForm;

using Squirrel;

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        private static InputLanguage urdu = InputLanguage.FromCulture(new CultureInfo("ur-PK"));
        private static InputLanguage english = InputLanguage.FromCulture(new CultureInfo("en-US"));
        public static Image AppBackground;
        public static string MainConnectionstring { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            bool createdNew;
            using (var mutex = new System.Threading.Mutex(true, "MyUniqueAppMutexName", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    SetBGImage();
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
                    builder.Encrypt = true;
                    builder.ConnectTimeout = 0;
                    builder.MaxPoolSize = 2000;
                    builder.TrustServerCertificate = true;
                    MainConnectionstring = builder.ConnectionString;
                    if (builder.DataSource.Split('\\')[0] == ".")
                    {
                        General.dbSystemName = Environment.MachineName;
                    }
                    else
                    {
                        General.dbSystemName = builder.DataSource.Split('\\')[0];
                    }
                    CheckForDatabaseUpgrade();

                    Application.ApplicationExit += OnExit;
                    var main = new frmMain();

                    Application.Run(main);
                }
                else
                { 
                BringToFront(); 
                }
            }
            
                

        }
        private static void BringToFront()
        {
            Process current = Process.GetCurrentProcess();
            foreach (var process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        ShowWindowAsync(handle, SW_RESTORE);
                        SetForegroundWindow(handle);
                    }
                    break;
                }
            }
        }
        public static void ResetBG()
        {
            if (AppBackground != null)
            {
                AppBackground.Dispose();
                AppBackground = null;
            }
            AppBackground = MandiPOS.Properties.Resources.bg1;
        }
        public static void SetBGImage()
        {
            string pth = GetBGImageFilePath();
            if (!string.IsNullOrWhiteSpace(pth))
            {
                // Dispose previous background image if exists
                if (AppBackground != null)
                {
                    AppBackground.Dispose();
                    AppBackground = null;
                }

                using (var stream = new FileStream(pth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var temp = Image.FromStream(stream))
                {
                    AppBackground = new Bitmap(temp); // this copy is safe
                }
            }
            else
            {
                if (AppBackground != null)
                {
                    AppBackground.Dispose();
                    AppBackground = null;
                }

                AppBackground = MandiPOS.Properties.Resources.bg1;
            }
        }

        static async Task CheckAndDownloadUpdateAsync(frmMain form)
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager(
                "https://github.com/GhayyasAwan/MandiPOS"))
            {


                var info = await mgr.CheckForUpdate();

                if (info.ReleasesToApply.Any())
                {
                    await mgr.DownloadReleases(info.ReleasesToApply).ConfigureAwait(false);

                    // marshal back to UI thread
                    form.Invoke((Action)(async () =>
                    {
                        var result = MessageBox.Show(
                            "New update ready. Install now?",
                            "Update Available",
                            MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            await mgr.ApplyReleases(info).ConfigureAwait(false);
                            UpdateManager.RestartApp();
                        }
                    }));
                }
            }
        }

        public static string GetBGImageFilePath()
        {
            string rootPath = Application.StartupPath; // Application root folder
            string[] imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            string bgImagePath = Directory.GetFiles(rootPath)
                .FirstOrDefault(file =>
                    imageExtensions.Contains(Path.GetExtension(file).ToLower()) &&
                    Path.GetFileName(file).ToLower().Contains("bg")
                );

            return bgImagePath; // Will be null if not found
        }
        private static void CheckForDatabaseUpgrade()
        {
            string path = Path.Combine(Application.StartupPath, "Scripts");
            var upgrader = DeployChanges.To
              .SqlDatabase(MainConnectionstring)
              .WithScriptsFromFileSystem(path, new FileSystemScriptOptions
              {
                  Extensions = new string[1] { "*.sql" },
                  IncludeSubDirectories = true
              })
              .LogToConsole()
              .WithTransaction()
              .Build();

            var pendingScripts = upgrader.GetScriptsToExecute();
            if (pendingScripts.Any())
            {
                var result = upgrader.PerformUpgrade();
                if (!result.Successful)
                {
                    MessageBox.Show("Upgrade failed:\n" + result.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database upgraded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void UrduInput(bool isUrdu = true)
        {
            if (isUrdu)
            {
                InputLanguage.CurrentInputLanguage = urdu;
            }
            else
            {
                InputLanguage.CurrentInputLanguage = english;
            }
        }

        private static void OnExit(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }
        private class FocusMessageFilter : IMessageFilter
        {
            private const int WM_ACTIVATEAPP = 0x001C;

            public bool PreFilterMessage(ref Message m)

            {
                if (m.Msg == WM_ACTIVATEAPP)
                {
                    bool activated = m.WParam != IntPtr.Zero;
                    if (activated)
                        InputLanguage.CurrentInputLanguage = urdu;
                    else
                        InputLanguage.CurrentInputLanguage = english;
                }
                return false;
            }
        }
    }
}
