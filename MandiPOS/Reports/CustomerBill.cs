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
        public CustomerBill(int CustomerID, DateTime date, List<clsCustomerBill> data)
        {
            InitializeComponent();
            
            var acc = DetailAccountService.GetDetailAccountByID(CustomerID);
            var city = SQL.GetCities().Where(x => x.ID == acc.CityID).FirstOrDefault();
            var prevBalance = new db().ExecuteScalar<decimal>("sp_Ledger", new { AccountID = CustomerID, GetBalanceBeforeDate = date.Date },
             commandType: CommandType.StoredProcedure);
            _prevbal.Text = Math.Abs(prevBalance).ToString("0.##");
            prevState.Text = prevBalance < 0 ? "جمع" : "بنام";
            lblPartyTitle.Text = $@"{acc.AccountTitle}";
            lblDate.Text = $@"{date:dd-MMM-yyyy}";
            this.DataSource = data;
            _laga.Text = data.Sum(x => x.Laga).ToString("0.##");
            decimal _totalAmount = 0;
            _totalAmount = data.Sum(x => x.Amount) + data.Sum(x => x.Laga);
            _netSale.Text = _totalAmount.ToString("0.##");
            decimal recAble = prevBalance + _totalAmount;
            _lastBalance.Text = $"{recAble.ToString("0.##")}";
            currstate.Text = recAble < 0 ? "جمع" : "بنام";

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

        private void xrTableCell2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
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
    }
}
