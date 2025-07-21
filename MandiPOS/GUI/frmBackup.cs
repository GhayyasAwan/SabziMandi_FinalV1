using System;
using System.IO;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frmBackup : Form
    {
        clsResize _clsResize;
        public frmBackup()
        {
            InitializeComponent();
            _clsResize = new clsResize(this);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog frm = new FolderBrowserDialog())
            {
                frm.Description = "Select Backup Folder";
                frm.ShowNewFolderButton = true;
                frm.RootFolder = Environment.SpecialFolder.MyComputer;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    editBox1.Text = frm.SelectedPath;
                }
            }
        }

        private void uiRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = uiRadioButton2.Checked;
        }
        string backupPath = "";
        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (uiRadioButton2.Checked)
            {
                // Perform backup to the specified folder
                try
                {
                    backupPath = editBox1.Text;
                    if (string.IsNullOrEmpty(backupPath))
                    {
                        MessageBox.Show("Please select a backup folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Call the backup helper method
                    SqlBackupHelper.BackupAndMoveDatabase(backupPath);
                    MessageBox.Show("Backup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (checkBox1.Checked)
                    {
                        // Optionally, open the backup folder after completion
                        System.Diagnostics.Process.Start("explorer.exe", backupPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (uiRadioButton1.Checked)
            {
                // Perform backup to the default location
                try
                {
                    backupPath = Path.Combine(Application.StartupPath, "Backup");
                    Directory.CreateDirectory(backupPath);
                    SqlBackupHelper.BackupAndMoveDatabase(backupPath);
                    MessageBox.Show("Backup completed successfully to the default location.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (checkBox1.Checked)
                    {
                        // Optionally, open the backup folder after completion
                        System.Diagnostics.Process.Start("explorer.exe", backupPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = uiRadioButton2.Checked;
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            _clsResize._get_initial_size();
            groupBox2.Enabled = uiRadioButton2.Checked;
        }
    }
}
