using MandiPOS.CLasses;
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
    public partial class frmCustomControl2 : Form
    {
        Bitmap bmp = new Bitmap(100, 100);
        byte[] bmpArray = null;
        DetailAccounts acc;
        public frmCustomControl2(int PartyID)
        {
            InitializeComponent();
            pb1.SizeMode = PictureBoxSizeMode.Zoom;
            acc = DetailAccountService.GetDetailAccountByID(PartyID);
        }

        private void frmCustomControl2_Load(object sender, EventArgs e)
        {
            if (acc.CustomLabel == null)
                bmp = new Bitmap(100, 100);
            else
            {
                using (var stream = new MemoryStream(acc.CustomLabel))
                {
                    bmp = new Bitmap(stream);
                }
            }
            bmpArray = ConvertBitmapToByteArray(bmp);
            pb1.Image = bmp;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bmp = new Bitmap(ofd.FileName);
                    bmpArray = ConvertBitmapToByteArray(bmp);
                }
            }
            pb1.Image = bmp;
        }
        public byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            if (bitmap == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                return ms.ToArray();
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (bmpArray != null)
            {
                try
                {
                    DetailAccountService.SaveCustomLabel(acc.ID, bmpArray);
                    this.Close();
                }
                catch (Exception ex)
                {
                    ex.ExcError();

                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            pb1.Image = null;
            bmp = new Bitmap(100, 100);
            bmpArray = ConvertBitmapToByteArray(bmp);
            pb1.Image = bmp;
        }
    }
}
