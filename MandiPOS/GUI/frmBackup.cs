using Janus.Windows.EditControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
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
            comboBoxDrives.SelectedIndexChanged += ComboBoxDrives_SelectedIndexChanged;
            rbRemoveable.CheckedChanged += RbRemoveable_CheckedChanged;
            rbDefault.CheckedChanged += RbDefault_CheckedChanged;
        }

        private void RbDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDefault.Checked)
            {
                backupPath = Path.Combine(Application.StartupPath, "Backup");
                txtTargetLoation.Text= backupPath;
            }
        }

        private void RbRemoveable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRemoveable.Checked && comboBoxDrives.SelectedItem != null)
            {
                txtTargetLoation.Text = comboBoxDrives.SelectedValue.ToString();
            }
        }

        private void ComboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbRemoveable.Checked && comboBoxDrives.SelectedItem != null)
            {
                txtTargetLoation.Text = comboBoxDrives.SelectedValue.ToString();
            }
        }
        private string FormatDriveSize(long bytes)
        {
            double size = (double)bytes;
            string unit = "Bytes";

            if (size >= 1024 * 1024 * 1024)
            {
                size = size / (1024 * 1024 * 1024);
                unit = "GB";
            }
            else if (size >= 1024 * 1024)
            {
                size = size / (1024 * 1024);
                unit = "MB";
            }
            else if (size >= 1024)
            {
                size = size / 1024;
                unit = "KB";
            }

            return $"{Math.Round(size, 2)} {unit}";
        }
        private void LoadRemovableDrivesWMI()
        {
            comboBoxDrives.Items.Clear();

            try
            {
                // STEP 1: Physical Disks (USB) ka data memory mein save karen
                Dictionary<uint, (string Model, long Size)> usbPhysicalDisks = new Dictionary<uint, (string, long)>();

                using (ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher("SELECT Index, Model, Size FROM Win32_DiskDrive WHERE InterfaceType = 'USB'"))
                {
                    foreach (ManagementObject disk in diskSearcher.Get())
                    {
                        if (disk["Index"] != null && disk["Size"] != null)
                        {
                            uint diskIndex = Convert.ToUInt32(disk["Index"]);
                            string model = disk["Model"]?.ToString() ?? "USB Drive";
                            long size = Convert.ToInt64(disk["Size"]);

                            usbPhysicalDisks[diskIndex] = (model, size);
                        }
                    }
                }

                // STEP 2: Partition aur Logical Drive ke links nikal kar C# List mein save karen
                List<(string Antecedent, string Dependent)> partitionLinks = new List<(string, string)>();
                using (ManagementObjectSearcher linkSearcher = new ManagementObjectSearcher("SELECT Antecedent, Dependent FROM Win32_LogicalDiskToPartition"))
                {
                    foreach (ManagementObject link in linkSearcher.Get())
                    {
                        string antecedent = link["Antecedent"]?.ToString();
                        string dependent = link["Dependent"]?.ToString();

                        if (!string.IsNullOrEmpty(antecedent) && !string.IsNullOrEmpty(dependent))
                        {
                            partitionLinks.Add((antecedent, dependent));
                        }
                    }
                }

                // STEP 3: Logical Disks (Removable drives jaise G:, H:) ko scan karen
                using (ManagementObjectSearcher logicalSearcher = new ManagementObjectSearcher("SELECT DeviceID, VolumeName FROM Win32_LogicalDisk WHERE DriveType = 2"))
                {
                    foreach (ManagementObject logical in logicalSearcher.Get())
                    {
                        string driveLetter = logical["DeviceID"]?.ToString(); // e.g., "G:"
                        if (string.IsNullOrEmpty(driveLetter)) continue;

                        string modelName = "Unknown USB";
                        string physicalSizeStr = "Unknown Size";
                        long physicalSizeBytes = 0; // Size ko bytes mein check karne ke liye variable

                        // STEP 4: C# ke andar Mapping-Logic chalayen
                        foreach (var link in partitionLinks)
                        {
                            if (link.Dependent.Contains($"\"{driveLetter}\""))
                            {
                                int startIndex = link.Antecedent.IndexOf("Disk #") + 6;
                                int endIndex = link.Antecedent.IndexOf(",", startIndex);

                                if (startIndex > 5 && endIndex > startIndex)
                                {
                                    string diskIndexStr = link.Antecedent.Substring(startIndex, endIndex - startIndex);

                                    if (uint.TryParse(diskIndexStr, out uint diskIndex))
                                    {
                                        if (usbPhysicalDisks.ContainsKey(diskIndex))
                                        {
                                            modelName = usbPhysicalDisks[diskIndex].Model;
                                            physicalSizeStr = FormatDriveSize(usbPhysicalDisks[diskIndex].Size);
                                            physicalSizeBytes = usbPhysicalDisks[diskIndex].Size; // Raw Bytes save kar liye
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        // STEP 5: DriveInfo use karen aur 500MB ki Condition check karen
                        DriveInfo di = new DriveInfo(driveLetter);
                        if (di.IsReady)
                        {
                            // 500 MB ki limit bytes mein set ki (500 * 1024 * 1024)
                            long minSizeInBytes = 500L * 1024L * 1024L;

                            // CONDITION: Agar USB ka total size 500MB ya us se bada hai tabhi add ho
                            if (di.AvailableFreeSpace >= minSizeInBytes)
                            {
                                string freeSpaceStr = FormatDriveSize(di.AvailableFreeSpace);

                                // Final format text
                                string displayText = $"{driveLetter}\\ {freeSpaceStr}/{physicalSizeStr}";
                                string valueText = $"{driveLetter}\\";
                                UIComboBoxItem item = new UIComboBoxItem()
                                {
                                    Text = displayText,
                                    Value = valueText,
                                    IsSeparator = false
                                };
                                comboBoxDrives.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Drives load karne mein masla aaya:\n" + ex.Message, "WMI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBoxDrives.Items.Count > 0)
            {
                rbRemoveable.Enabled = true;
                rbRemoveable.Checked = true;
                comboBoxDrives.SelectedIndex = 0;
                RbRemoveable_CheckedChanged(null, null);
            }
            else
            {
                rbRemoveable.Enabled = false;
                rbDefault.Checked = true;
                RbDefault_CheckedChanged(null, null);
            }
        }
        private void LoadRemovableDrivesOld()
        {
            comboBoxDrives.Items.Clear(); // Purani list saaf karen

            // System ki tamam drives check karen
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                // Sirf Removable drives select karen
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                {
                    string totalStr = FormatDriveSize(drive.TotalSize);
                    string freeStr = FormatDriveSize(drive.AvailableFreeSpace);

                    // Format: E:\ 99.00 MB / 15.50 MB Free
                    string driveInfo = $"{drive.Name} {totalStr} / {freeStr} Free";

                    comboBoxDrives.Items.Add(driveInfo);
                }
            }

            // Agar koi drive mili, to pehli wali select kar len
            if (comboBoxDrives.Items.Count > 0)
            {
                comboBoxDrives.SelectedIndex = 0;
                txtTargetLoation.Text = comboBoxDrives.SelectedItem.ToString();
            }
            else
            {
                comboBoxDrives.SelectedIndex = -1;
                rbRemoveable.Enabled = false;
                rbRemoveable.Checked = false;
                rbDefault.Checked = true;
            }
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
                    txtTargetLoation.Text = frm.SelectedPath;
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
                    backupPath = txtTargetLoation.Text;
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
            else if (rbDefault.Checked)
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
            else if (rbRemoveable.Checked)
            {
                backupPath = txtTargetLoation.Text;
                if (comboBoxDrives.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxDrives.Text.Trim()) || string.IsNullOrEmpty(txtTargetLoation.Text.Trim())||string.IsNullOrEmpty(backupPath))
                {
                    this.Error("Please Select Proper Removeable Disk.");
                    return;
                }
                SqlBackupHelper.BackupAndMoveDatabase(backupPath);
                MessageBox.Show("Backup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (checkBox1.Checked)
                {
                    // Optionally, open the backup folder after completion
                    System.Diagnostics.Process.Start("explorer.exe", backupPath);
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
            LoadRemovableDrivesWMI();
            //rbDefault.Checked = true;
            //RbDefault_CheckedChanged(null, null);

        }
        protected override void WndProc(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x0219;
            if (m.Msg == WM_DEVICECHANGE)
            {
                // Jab bhi device change ho, list refresh kar len
                LoadRemovableDrivesWMI();
            }
            base.WndProc(ref m);
        }
    }
}
