using Dapper;
using DevExpress.DataAccess.Wizard.Views;
using MandiPOS.CLasses;

using System;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class rptVendorSale : DevExpress.XtraReports.UI.XtraReport
    {
        public rptVendorSale(DateTime date, int PartyID = 0)
        {
            InitializeComponent();
            var data = new db().Query<vw_vendorSale>($"Select * from vw_vendorSale Where ArrivalDate='{date:yyyy-MM-dd}' {(PartyID == 0 ? "" : $" and PartyID='{PartyID}'")}");
            if (!data.Any())
            {
                General.Info("No records found for the selected date and party.");
                this.Dispose();
                return;
            }
            if (!General.IsAdmin)
            {
                foreach (var d in data)
                {
                    d.TotalLaga = 0.ToString();
                    d.CommissionAmount = 0;
                    d.MunshianaAmount = 0;
                    d.MazdooriAmount = 0;
                }
            }
            this.DataSource = data;
            xrLabel1.Text = $"{date:dd-MMM-yyyy}";
            string items = new db().ExecuteScalar<string>($"Exec sp_GetItemsDetails '{date:yyyy-MM-dd}','{PartyID}'");
            lblItems.Text = items;
        }

        private void xrTableCell7_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private static void SetFormat(object sender)
        {
            var cell = sender as DevExpress.XtraReports.UI.XRTableCell;
            if (cell != null)
            {
                // Check if the value is 0 (you might need to handle different numeric types)
                if (cell.Text == "0"||cell.Text==cell.Name || cell.Text == "0.00" || cell.Text == "0.0" || cell.Value == null || cell.Value == (object)0)
                {
                    cell.Text = "";
                }
            }
        }

        private void xrTableCell11_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell10_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell9_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell8_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell6_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell36_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell35_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell34_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell33_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell32_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell31_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell27_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell28_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell29_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell30_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell31_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell32_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell33_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell34_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell35_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }

        private void xrTableCell36_BeforePrint_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetFormat(sender);
        }
    }
}
