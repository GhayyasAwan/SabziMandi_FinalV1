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
    public partial class frmCustomLabel : Form
    {
        Bitmap bmp=new Bitmap(100,100);
        byte[] bmpArray;
        DetailAccounts acc;
        public frmCustomLabel(int PartyID)
        {
            InitializeComponent();
            acc = DetailAccountService.GetDetailAccountByID(PartyID);
            this.Load += FrmCustomLabel_Load;
        }

        private void FrmCustomLabel_Load(object sender, EventArgs e)
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
            bmpArray=ConvertBitmapToByteArray(bmp);
            pb.Image = bmp;

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bmp = new Bitmap(ofd.FileName);
                    bmpArray=ConvertBitmapToByteArray(bmp);
                }
            }
            pb.Image = bmp;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pb.Image = null; bmp = null;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (bmp != null && bmpArray != null)
            {
                try
                {
                    DetailAccountService.SaveCustomLabel(acc.ID, bmpArray);
                }
                catch (Exception ex)
                {
                    ex.ExcError();
                   
                }
            }
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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (this.Ask("Do you really want to remove this label?"))
            {
                try
                {
                    DetailAccountService.SaveCustomLabel(acc.ID, null);
                }
                catch (Exception ex)
                {
                    ex.ExcError();
                }
            }
        }
    }
}
