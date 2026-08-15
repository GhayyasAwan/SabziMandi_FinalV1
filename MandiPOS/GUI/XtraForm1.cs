using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MandiPOS.GUI
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        XtraReport Report { get; set; }
        bool IsBill = false;
        public XtraForm1(XtraReport rpt, bool bill = false, bool isPrepared = false)
        {
            InitializeComponent();
            if (!isPrepared)
            {
                rpt.CreateDocument();
            }
            IsBill = bill;
            this.WindowState = FormWindowState.Maximized;
            Report = rpt;
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyDown += XtraForm1_KeyDown;
            this.documentViewer1.DocumentSource = Report;
            this.Load += XtraForm1_Load;
            this.documentViewer1.DocumentChanged += DocumentViewer1_DocumentChanged;
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
            // Force report creation complete before scrolling
            // this.documentViewer1.Zoom = 100; // optional: ensure zoom applied

            // Delay scrolling until report is fully rendered

            documentViewer1.PrintingSystem.ExecCommand(PrintingSystemCommand.ZoomToPageWidth);
            Program.waitFormInstance?.Dispose();
            if (IsBill)
            {
                this.BeginInvoke(new Action(() =>
                {
                    var verticalScroll = documentViewer1.VerticalScroll;
                    if (verticalScroll != null)
                    {
                        verticalScroll.Value = Math.Min(verticalScroll.Maximum, 100); // scroll 100px down
                    }
                }));
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

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            // Inside your method
            Thread staThread = new Thread(() =>
            {
                try
                {
                    // Choose a folder to save exported images
                    using (var fbd = new FolderBrowserDialog())
                    {
                        fbd.Description = "Select folder to export report pages as images";
                        if (fbd.ShowDialog() != DialogResult.OK)
                            return;

                        string exportFolder = fbd.SelectedPath;

                        ImageExportOptions imageOptions = this.Report.ExportOptions.Image;
                        imageOptions.Resolution = 300;
                        imageOptions.Format = ImageFormat.Png; // Or your preferred format
                        imageOptions.ExportMode = ImageExportMode.DifferentFiles; // Crucial for individual page export

                        // Export the report. DevExpress will automatically create files for each page
                        // when ExportMode is SingleFilePageByPage and you provide a file path.
                        // The file name will be suffixed with "_<page_number>".
                        string baseFileName = Path.Combine(exportFolder, "ReportPage.png");
                        this.Report.ExportToImage(baseFileName, imageOptions);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting report: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();

        }
    }
}