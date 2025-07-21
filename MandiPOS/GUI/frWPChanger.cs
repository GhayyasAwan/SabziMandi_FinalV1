using DevExpress.XtraReports.UI;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frWPChanger : Form
    {
        public frWPChanger()
        {
            InitializeComponent();
            this.Load += FrWPChanger_Load;
        }
        string filePath = "";
        private void FrWPChanger_Load(object sender, EventArgs e)
        {
            filePath = Program.GetBGImageFilePath();
            ShowImage();
        }

        private void ShowImage()
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                this.pictureBox1.Image = Image.FromFile(filePath);
            }
            else
            {
                this.pictureBox1.Image = Properties.Resources.bg1;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath=ofd.FileName;
                    ShowImage();
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
          
            try
            {
                Program.ResetBG();
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    string extension = Path.GetExtension(filePath); // e.g. .jpg or .png
                    string destPath = Path.Combine(Application.StartupPath, "bg" + extension);

                    File.Copy(filePath, destPath, overwrite: true);

                    MessageBox.Show($"Image saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select an image first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ex.ExcError();
            }
        }
    }
}
