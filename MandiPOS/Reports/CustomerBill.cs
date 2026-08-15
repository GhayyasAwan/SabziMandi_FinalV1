
using Dapper;
using DevExpress.XtraReports.UI;
using MandiPOS.CLasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MandiPOS.Reports
{
    public partial class CustomerBill : DevExpress.XtraReports.UI.XtraReport
    {
        public CustomerBill(int CustomerID, DateTime date)
        {
            InitializeComponent();
            this.HideWarnings();
            string sql = $@"SELECT 
	p.ItemTitle as 'Item',
    CustomerRate  as Rate,
    SUM(ItemQty) AS Qty,
    SUM(ItemWeight) AS 'Weight',
    SUM(CustomerAmount) AS Amount,
    SUM(LagaAmount) AS Laga
FROM (
    SELECT 
        sd.PartyID,
        sd.ItemID,
        sd.ItemQty,
        sd.ItemWeight,
        sd.CustomerRate,
        sd.CustomerAmount,
        sd.LagaAmount 
    FROM tblsale s 
    LEFT JOIN tblSaleDetail sd ON s.ID = sd.SaleID
    WHERE s.ArrivalDate = '{date:yyyy-MM-dd}' AND sd.PartyID = '{CustomerID}'
) AS SubQuery
left join tblItems p on SubQuery.ItemID=p.ID
GROUP BY 
   p.ItemTitle,
    CustomerRate
ORDER BY 
    p.ItemTitle";
            List<clsCustomerBill> data = new db().Query<clsCustomerBill>(sql).ToList();
            var acc = DetailAccountService.GetDetailAccountByID(CustomerID);
            var city = SQL.GetCities().Where(x => x.ID == acc.CityID).FirstOrDefault();
            var prevBalance = new db().ExecuteScalar<decimal>("sp_Ledger", new { AccountID = CustomerID, GetBalanceBeforeDate = date.Date },
             commandType: CommandType.StoredProcedure);
            _prevbal.Text = Math.Abs(prevBalance).ToString("N0");
            //prevState.Text = prevBalance < 0 ? "جمع" : "بنام";
            lblPartyTitle.Text = $@"{acc.AccountTitle}";
            lblDate.Text = $@"{date:dd-MMM-yyyy}";
            this.DataSource = data;
            _laga.Text = data.Sum(x => x.Laga).ToString("N0");
            decimal _totalAmount = 0;
            _totalAmount = data.Sum(x => x.Amount) + data.Sum(x => x.Laga);
            _netSale.Text = _totalAmount.ToString("N0");
            decimal recAble = prevBalance + _totalAmount;
            _lastBalance.Text = $"{recAble.ToString("N0")}";
            //currstate.Text = recAble < 0 ? "جمع" : "بنام";

        }

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
        decimal qty= 0;
        decimal weight= 0;
        
        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

            XRTableCell cell = sender as XRTableCell;
            if (cell == null) return;

            // Get the current row from the report's datasource
            var row = GetCurrentRow() as clsCustomerBill;
            if (row == null) return;
            qty += row.Qty;
            weight += row.Weight;
            cell.RightToLeft = RightToLeft.Yes;
            
            // Decide what to display
            if (row.Weight != 0)
            {
                cell.Text = $"{row.Qty.ToString("N0")} / {row.Weight.ToString("N0")}کلو";
            }
            else
            {
                cell.Text = $"{row.Qty.ToString("N0")}";
            }
        }

        private void xrTableCell13_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell == null) return;
            cell.RightToLeft = RightToLeft.Yes;
            if (weight==0)
                cell.Text = $"{qty:N0}";
            else
                cell.Text = $"{qty:N0}/{weight:N0}کلو";
        }
    }
}
