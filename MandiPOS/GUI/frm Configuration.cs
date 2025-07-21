using MandiPOS.CLasses;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class frm_Configuration : Form
    {
        private string BGIMageName = string.Empty;
        public frm_Configuration()
        {
            InitializeComponent();
            this.Load += Frm_Configuration_Load;
        }

        private void Frm_Configuration_Load(object sender, EventArgs e)
        {
            tblConfigs cfgBG = configService.GetConfigByName("BGImage");
            BGIMageName = cfgBG.ConfigValue;
            if (!string.IsNullOrEmpty(BGIMageName) && File.Exists(BGIMageName))
            {

            }
        }

        private void ChooseImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter for image files
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                this.pictureBox1.Image = Image.FromFile(selectedImagePath);
            }
        }
    }
}
