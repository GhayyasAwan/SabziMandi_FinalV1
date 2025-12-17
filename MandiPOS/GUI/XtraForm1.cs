using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        XtraReport Report { get; set; }
        float _zoom = 1.5f;
        public XtraForm1(XtraReport rpt, float zoom=1.5f)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
            Report = rpt;
            _zoom = zoom;
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyDown += XtraForm1_KeyDown;
            
            this.documentViewer1.DocumentSource = Report;

            this.Activated += XtraForm1_Activated;
            this.Load += XtraForm1_Load;
            
            
        }

        private void XtraForm1_Activated(object sender, EventArgs e)
        {
            SetZoom();
        }

        private void XtraForm1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            // // Force report creation complete before scrolling
            //// this.documentViewer1.Zoom = 100; // optional: ensure zoom applied

            // // Delay scrolling until report is fully rendered
            // this.BeginInvoke(new Action(() =>
            // {
            //     var verticalScroll = documentViewer1.VerticalScroll;
            //     if (verticalScroll != null)
            //     {
            //         verticalScroll.Value = Math.Min(verticalScroll.Maximum, 100); // scroll 100px down
            //     }
            // }));
            this.documentViewer1.DocumentChanged += DocumentViewer1_DocumentChanged;
            SetZoom();
        }

        private void SetZoom()
        {
            if (_zoom != 1.5f)
            {
                documentViewer1.PrintingSystem.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
            }
            else
            {
                documentViewer1.Zoom = _zoom;
               // documentViewer1.PrintingSystem.ExecCommand(PrintingSystemCommand.Zoom);
            }
        }

        private void DocumentViewer1_DocumentChanged(object sender, EventArgs e)
        {
            
        }

        private void bbiScale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Thread staThread = new Thread(() =>
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Report.CreateDocument();
                        Report.ExportToPdf(sfd.FileName);

                        Process.Start(new ProcessStartInfo(sfd.FileName)
                        {
                            UseShellExecute = true
                        });
                    }
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }
    }
}