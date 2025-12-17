using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class saleBill : DevExpress.XtraReports.UI.XtraReport
    {
        public saleBill(string id, int IdType = 0)
        {
            InitializeComponent();
            object cart = new object();
            object summary = new object();
            tblSale sale = new tblSale();
            this.HideWarnings();
            //idType 0 = SaleID, 1 = Billno
            if (IdType == 0)
            {
                sale = SaleService.GetSaleByID(id.toInt(), ref cart, ref summary);
            }
            else
            {
                sale = SaleService.GetSaleByArrivalNo(id.toInt(), ref cart, ref summary);
            }
            if (!string.IsNullOrEmpty(sale.Marka))
            {
                //lblMarka.Text = $@"مارکہ {sale.Marka} ";
            }
            else
            {
               // lblMarka.Text = string.Empty;
            }
            DetailAccounts acc = DetailAccountService.GetDetailAccountByID(sale.PartyID);
            if (acc.AccountTitle.Contains("نقد") && !string.IsNullOrEmpty(sale.PartyTitle))
            {
                lblPartyTitle.Text = $"{sale.PartyTitle}";
            }
            else
            {
                lblPartyTitle.Text = $"{acc.AccountTitle}";
            }

            lblBillNO.Text = $"{sale.ArrivalNo}";
            lblDate.Text = $"{sale.ArrivalDate:dd-MMM-yyyy}";
            decimal Grossale = 0;


            List<vwSale3> newCart = new List<vwSale3>();


            //foreach (vwSale3 d in (cart as List<vwSale3>))
            //{
            //    Grossale += d.PartyAmount;
            //    if (!string.IsNullOrEmpty(d.Marka))
            //    {
            //        d.ItemTitle = $"{d.ItemTitle}  {d.Marka}";
            //    }

            //    if (newCart.Any(x => x.ItemID == d.ItemID && x.ParyRate == d.ParyRate))
            //    {
            //        vwSale3 existingItem = newCart.FirstOrDefault(x => x.ItemID == d.ItemID && x.ParyRate == d.ParyRate);
            //        existingItem.PartyAmount += d.PartyAmount;
            //        existingItem.ItemQty += d.ItemQty;
            //    }
            //    else
            //    {
            //        newCart.Add(d);
            //    }
            //}


            newCart = cart as List<vwSale3>;

            this.DataSource = newCart.OrderByDescending(x => x.ParyRate);
            decimal total = 0, commission = 0, mazdoori = 0, munshiana = 0, karaya = 0, store = 0, _sale=0;
            Grossale = newCart.Sum(x => x.PartyAmount);
            commission = sale.CommissionAmount;
            mazdoori = sale.MazdooriAmount;
            munshiana = sale.MunshianaAmount;
            karaya = sale.KarayaAmount;
            rowKarya.Visible = karaya != 0;
            store = sale.StoreRent;
            total = commission + mazdoori + munshiana +  store;
            _commission.Text = commission.ToString("N0");
            _mazdoori.Text = mazdoori.ToString("N0");
            _munshiana.Text = munshiana.ToString("N0");
            _kraya.Text = karaya.ToString("N0");
            //_store.Text = store.ToString("N0");
            _total.Text = total.ToString("N0");
            _expenses.Text = total.ToString("N0");
            _netSale.Text = (Grossale - total).ToString("N0");
            decimal tobePaid = (Grossale - total - karaya) - sale.PaidAmount;
            rowPaid.Visible = true;
            lblNetPaidValue.Text = sale.PaidAmount.ToString("0,0.##");
                rowPaid.Visible = true;
                lblRemAmountValue.Text = Math.Abs(tobePaid).ToString("0,0.##");
                lblRemAmountValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        }
        decimal qty = 0;
        decimal weight = 0;
        private void xrTableCell1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null)
            {
                // Check if the value is 0 (you might need to handle different numeric types)
                if (cell.Text == "0" || cell.Text == "0.00" || cell.Text == "0.0")
                {
                    cell.Text = "";
                }
            }
        }

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell == null) return;

            // Get the current row from the report's datasource
            var row = GetCurrentRow() as vwSale3;
            if (row == null) return;
            qty += row.ItemQty;
            weight += row.ItemWeight;
            cell.RightToLeft = RightToLeft.Yes;
            // Decide what to display
            if (row.ItemWeight != 0)
            {
                cell.Text = $"{row.ItemQty.ToString("0.##")} / {row.ItemWeight.ToString("0.##")}کلو";
            }
            else
            {
                cell.Text = $"{row.ItemQty.ToString("0.##")}";
            }
        }

        private void lblTotalQty_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            
            if (cell == null) return;
            cell.RightToLeft = RightToLeft.Yes;
            if (weight == 0)
            {
                cell.Text = $"{qty:0.##}";
            }
            else
            {
                cell.Text = $"{weight:0.##}/{qty:0.##}کلو";
            }
        }
    }
}
