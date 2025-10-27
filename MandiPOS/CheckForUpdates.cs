using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS
{
    public class UpdateForm : Form
    {
        private readonly string connectionString;
        private string releaseUrl;
        private string currentVersion;
        private TextBox txtUpdatePath;
        private Button btnCheck;
        private Button btnDownload;
        private ProgressBar progressBar;
        private string downloadPath;
        private static readonly HttpClient httpClient = new HttpClient();

        public UpdateForm(string connectionString)
        {
            this.connectionString = connectionString;
            httpClient.DefaultRequestHeaders.Add("User-Agent", "UpdateFormLibrary");
            InitializeComponents();
            this.Load += UpdateForm_Load;
        }

        private void InitializeComponents()
        {
            this.Text = "Software Update";
            this.Size = new Size(400, 300);

            // Label
            var lbl = new Label
            {
                Text = "Update Path:",
                Location = new Point(10, 10)
            };
            this.Controls.Add(lbl);

            // Readonly TextBox for GitHub release URL
            txtUpdatePath = new TextBox
            {
                ReadOnly = true,
                Location = new Point(100, 10),
                Width = 280
            };
            this.Controls.Add(txtUpdatePath);

            // Check button
            btnCheck = new Button
            {
                Text = "Check for Latest Release",
                Location = new Point(10, 50)
            };
            btnCheck.Click += BtnCheck_Click;
            this.Controls.Add(btnCheck);

            // Download button (initially disabled)
            btnDownload = new Button
            {
                Text = "Download Update",
                Location = new Point(200, 50),
                Enabled = false
            };
            btnDownload.Click += BtnDownload_Click;
            this.Controls.Add(btnDownload);

            // Progress bar (initially hidden)
            progressBar = new ProgressBar
            {
                Location = new Point(10, 100),
                Width = 370,
                Visible = false
            };
            this.Controls.Add(progressBar);
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            try
            {
                releaseUrl = GetSetting("GitHubReleaseUrl");
                currentVersion = GetSetting("SoftwareVersion");
                txtUpdatePath.Text = releaseUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message);
                this.Close();
            }
        }

        private string GetSetting(string key)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Value FROM settings WHERE SettingKey = @key", conn))
                {
                    cmd.Parameters.AddWithValue("@key", key);
                    return cmd.ExecuteScalar() as string;
                }
            }
        }

        private async void BtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var json = await httpClient.GetStringAsync(releaseUrl);
                using (var document = JsonDocument.Parse(json))
                {
                    var root = document.RootElement;
                    var webVersion = root.GetProperty("tag_name").GetString()?.TrimStart('v');
                    var assets = root.GetProperty("assets");
                    string downloadUrl = "";
                    downloadUrl = assets.EnumerateArray().FirstOrDefault().GetProperty("browser_download_url").GetString();
                    if (string.IsNullOrEmpty(webVersion) || string.IsNullOrEmpty(downloadUrl))
                    {
                        MessageBox.Show("Failed to retrieve release information.");
                        return;
                    }

                    var webVer = new Version(webVersion);
                    var currVer = new Version(currentVersion);

                    if (webVer > currVer)
                    {
                        btnDownload.Enabled = true;
                        btnDownload.Tag = downloadUrl; // Store download URL
                        MessageBox.Show($"New version available: {webVersion}");
                    }
                    else
                    {
                        MessageBox.Show("You have the latest version.");
                    }
                }
            }
          
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for update: " + ex.Message);
            }
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var downloadUrl = btnDownload.Tag as string;
                if (string.IsNullOrEmpty(downloadUrl))
                {
                    MessageBox.Show("No download URL available.");
                    return;
                }

                downloadPath = Path.Combine(Application.StartupPath, "update.exe");

                progressBar.Visible = true;
                progressBar.Value = 0;
                btnDownload.Enabled = false;
                btnCheck.Enabled = false;

                using (var response = await httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var contentLength = response.Content.Headers.ContentLength;
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var buffer = new byte[8192];
                        long totalRead = 0;
                        int read;
                        while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, read);
                            totalRead += read;

                            if (contentLength.HasValue)
                            {
                                var progress = (int)((totalRead * 100) / contentLength.Value);
                                progressBar.Value = progress;
                            }
                        }
                    }
                }

                progressBar.Visible = false;
                MessageBox.Show("Download complete.");
                Process.Start(downloadPath);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during download: " + ex.Message);
                progressBar.Visible = false;
                btnDownload.Enabled = true;
                btnCheck.Enabled = true;
            }
        }
    }
}