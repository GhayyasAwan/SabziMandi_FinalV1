using Dapper;

using DevExpress.DataProcessing.InMemoryDataProcessor;

using System;
using System.ComponentModel;
using System.Data;

namespace MandiPOS.Reports
{
    public partial class rptRokar : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtJamaMaster = new DataTable();
        DataTable dtBanamMaster = new DataTable();
        DateTime _date; decimal 
            totaljama = 0, totalbanam = 0, openingCash = 0;
        decimal PrevBalance = 0;
        public rptRokar(DateTime date)
        {
            InitializeComponent();
            this.HideWarnings();
            _date = date;
            openingCash = 0;
            lblRokarDate.Text = _date.ToString("dd/MM/yyyy");
            lblPrintDate.Text = DateTime.Now.ToString("dd-MMM-yyyy h:m tt");
            if (openingCash < 0)
            {
                lblPrevBal.Text = Math.Abs(openingCash).ToString("N0");
                lblPrevBalState.Text = "جمع";
            }
            else
            {
                lblPrevBal.Text = openingCash.ToString("N0");
                lblPrevBalState.Text = "بنام";
            }
            GetPrevious();
            GetSummaryBalances();

            lblPrevBal.TextFormatString = "{0:N0}";
            xrSubreport1.BeforePrint += CollectJamaEntries;
            xrSubreport2.BeforePrint += CollectBanamEntries;
            this.AfterPrint += RptRokar_AfterPrint;

        }

        private void GetSummaryBalances()
        {
            decimal wasooli=0, expense=0, banam=0;

            string sql = "";


            _expnse.Text = expense.ToString("N0");
            _wasooli.Text = wasooli.ToString("N0");
            _banam.Text = banam.ToString("N0");
        }

        private void GetPrevious()
        {
//            string sql = "";
//            sql = $@"Declare @date date;
//Set @date='{_date:yyyy-MM-dd}';

//Select AccountTitle,Narration,Sum(CreditAmount) as 'Amount' from vw_BankEntries 
//Where VoucherDate>'2025-01-01' and VoucherDate<@date and CreditAmount<>0 and 
//AccountID in (Select ID from vwBankAccounts) 
//Group By AccountTitle,Narration
//union All
//Select AccountTitle,Narration,Sum(CreditAmount) as 'Amount' from vwTrx
//Where 1=1 and VoucherType=1 and CreditAmount<>0 and AccountID not in (Select ID from vwBankAccounts)
//and VoucherDate>'2025-01-01' and VoucherDate<@date
//Group By AccountTitle,Narration
//union All
//Select AccountTitle,'' as Narration,Sum(CreditAmount) as 'Amount' from vwTrx
//Where 1=1 and  CreditAmount<>0 and AccountID in (Select ID From DetailAccounts Where MasterID=2)
//and VoucherDate>'2025-01-01' and VoucherDate<@date
//Group by AccountTitle
//Union All
//Select AccountTitle+' '+CityName as 'AccountTitle',Narration,DebitAmount*-1 as 'Amount' from tblSale sale left join tblSaleDetail detail on sale.id=detail.SaleID
//  left join JVEntries jv on sale.VoucherID=jv.VoucherID
//  left join DetailAccounts acc on jv.AccountID=acc.ID
//  left join tblCity city on acc.CityID=city.ID
//  Where sale.ArrivalDate<@date and DebitAmount<>0 and MasterID=4
//union all
//Select AccountTitle,Narration,CreditAmount as Amount from (Select * from vwTrx
//Where VoucherType=4 and CreditAmount<>0
//and VoucherDate>'2025-01-01' and  VoucherDate<@date) tbl 
//where MasterAccount in (Select AccountTitle from MasterAccounts where ID=4)
//";
//            ////DataTable jama = General.FetchRecords(sql, null);
//            sql = $@"Declare @date date;
//Set @date='{_date:yyyy-MM-dd}';

//Select city.CityName+' '+acc.AccountTitle as 'AccountTitle',vd.Narration+' =>'+acc2.AccountTitle as 'Narration',vd.Amount as 'Amount' from Vouchers vm
//Left join VoucherDetails vd on vm.VoucherID=vd.VoucherID
//left join DetailAccounts acc on vd.PartyID=acc.ID
//left join tblCity city on acc.CityID=city.ID
//left join DetailAccounts acc2 on vd.CashAccountID=acc2.id
//Where vm.VoucherDate<@date and VoucherType=0
//and vd.CashAccountID in (Select ID from vwBankAccounts)
//union all
//Select city.CityName+' '+acc.AccountTitle as 'AccountTitle',vd.Narration,vd.Amount as 'Amount' from Vouchers vm
//Left join VoucherDetails vd on vm.VoucherID=vd.VoucherID
//left join DetailAccounts acc on vd.PartyID=acc.ID
//left join DetailAccounts acc2 on vd.CashAccountID=acc2.id
//left join tblCity city on acc.CityID=city.ID

//Where vm.VoucherDate<@date and VoucherType=0
//and vd.CashAccountID Not in (Select ID from vwBankAccounts)
//union all
//Select city.CityName+' '+acc2.AccountTitle as 'AccountTitle',vd.Narration+' =>'+acc.AccountTitle as 'Narration',vd.Amount as 'Amount' from Vouchers vm
//Left join VoucherDetails vd on vm.VoucherID=vd.VoucherID
//left join DetailAccounts acc on vd.PartyID=acc.ID
//left join DetailAccounts acc2 on vd.CashAccountID=acc2.id
//left join tblCity city on acc2.CityID=city.ID
//Where vm.VoucherDate<@date and VoucherType=1 
//and vd.CashAccountID in (Select ID from vwBankAccounts)

//union all
//Select * from (Select Top (100) percent city.CityName+' '+acc.AccountTitle as 'AccountTitle', ItemTitle+' '+Cast(Case when ItemUnit=0 then Cast(Floor(ItemQty) as Nvarchar) else Cast(Floor(ItemWeight) as nvarchar)  End as nvarchar)+'*'+Cast(Floor(CustomerRate) as nvarchar) as 'Narration',CustomerAmount+LagaAmount as 'amount' from tblSale main 
//left join tblSaleDetail sdetail on main.id=sdetail.SaleID
//left join tblItems on sdetail.ItemID=tblItems.ID
//left join DetailAccounts acc on sdetail.PartyID=acc.ID
//left join tblcity city on acc.CityID=city.ID
//Where main.ArrivalDate<@date and 
//AccountTitle not like N'نقد سیل'
//Order by sdetail.ID) tbl
//";
//            DataTable banam = General.FetchRecords(sql, null);

            decimal opCash = new db().ExecuteScalar<decimal>($"Select Abs(Isnull(OpDebit,0)-ISNULL(opcredit,0)) as 'OpBal' from DetailAccounts Where AccountTitle like N'کیش روکڑ'");
            decimal prevJama = new db().ExecuteScalar<decimal>($"Select Sum(Amount) as Amount From (Select EntryDate,Sum(Amount) as 'Amount' from vw_JamaRokar Where  EntryDate > '2025-01-01' Group By EntryDate) tbl Where EntryDate<'{_date:yyyy-MM-dd}'");
            decimal prevBanam = new db().ExecuteScalar<decimal>($"Select Sum(Amount) as Amount From (Select EntryDate,Sum(Amount) as 'Amount' from vw_BanamRokar Where  EntryDate > '2025-01-01' Group By EntryDate) tbl where EntryDate<'{_date:yyyy-MM-dd}'");


            // ✅ FIXED: Subtract Jama (credit), Add Banam (debit)
            openingCash = prevBanam-prevJama-opCash;

            // Display logic (correct)
            if (openingCash < 0)
            {
                lblPrevBal.Text = Math.Abs(openingCash).ToString("N0");
                lblPrevBalState.Text = "جمع";  // Credit (negative)
            }
            else
            {
                lblPrevBal.Text = openingCash.ToString("N0");
                lblPrevBalState.Text = "بنام";  // Debit (positive)
            }

        }

        private void RptRokar_AfterPrint(object sender, EventArgs e)
        {
            GetTotal();

        }

        private void GetTotal()
        {
            decimal _currentBalance = 0;
            if (totaljama > 0)
            {
                totaljama = totaljama * -1;
            }

            _currentBalance = openingCash + totaljama + totalbanam;
            cellJamaTotal.Text = Math.Abs(totaljama).ToString("N0");
            lblTotalJama.Text = Math.Abs(totaljama + openingCash).ToString("N0");
            lblTotalBanam.Text = cellBanamTotal.Text = totalbanam.ToString("N0");
            lblRemainingCash.Text = Math.Abs(_currentBalance).ToString("N0");
            lblEndBalanceState.Text = _currentBalance < 0 ? "جمع" : "بنام";
        }

        private void CollectBanamEntries(object sender, CancelEventArgs e)
        {
            string sql = "";
            #region Old Version
            //            //Collecting Data
            //            sql = $@"Select city.CityName+' '+acc.AccountTitle as 'AccountTitle',vd.Narration+' =>'+acc2.AccountTitle as 'Narration',vd.Amount as 'Amount' from Vouchers vm
            //Left join VoucherDetails vd on vm.VoucherID=vd.VoucherID
            //left join DetailAccounts acc on vd.PartyID=acc.ID
            //left join tblCity city on acc.CityID=city.ID
            //left join DetailAccounts acc2 on vd.CashAccountID=acc2.id
            //Where vm.VoucherDate=@date and VoucherType=0
            //and vd.CashAccountID in (Select ID from vwBankAccounts)";
            //            var dt1 = General.FetchRecords(sql, new { date = _date });
            //            sql = $@"Select city.CityName+' '+acc.AccountTitle as 'AccountTitle',vd.Narration,vd.Amount as 'Amount' from Vouchers vm
            //Left join VoucherDetails vd on vm.VoucherID=vd.VoucherID
            //left join DetailAccounts acc on vd.PartyID=acc.ID
            //left join DetailAccounts acc2 on vd.CashAccountID=acc2.id
            //left join tblCity city on acc.CityID=city.ID

            //Where vm.VoucherDate=@date and VoucherType=0
            //and vd.CashAccountID Not in (Select ID from vwBankAccounts)";
            //            var dt2 = General.FetchRecords(sql, new { date = _date });
            //            sql = $@"Select city.CityName+' '+acc2.AccountTitle as 'AccountTitle',vd.Narration+' =>'+acc.AccountTitle as 'Narration',vd.Amount as 'Amount' from Vouchers vm
            //Left join VoucherDetails vd on vm.VoucherID=vd.VoucherID
            //left join DetailAccounts acc on vd.PartyID=acc.ID
            //left join DetailAccounts acc2 on vd.CashAccountID=acc2.id
            //left join tblCity city on acc2.CityID=city.ID
            //Where vm.VoucherDate=@date and VoucherType=1 
            //and vd.CashAccountID in (Select ID from vwBankAccounts)";
            //            var dt3 = General.FetchRecords(sql, new { date = _date });
            //            sql = $@"Select  city.CityName+' '+acc.AccountTitle as 'AccountTitle', ItemTitle+' '+Cast(Case when ItemUnit=0 then Cast(Floor(ItemQty) as Nvarchar) else Cast(Floor(ItemWeight) as nvarchar)  End as nvarchar)+'*'+Cast(Floor(CustomerRate) as nvarchar) as 'Narration',CustomerAmount+LagaAmount as 'amount' from tblSale main 
            //left join tblSaleDetail sdetail on main.id=sdetail.SaleID
            //left join tblItems on sdetail.ItemID=tblItems.ID
            //left join DetailAccounts acc on sdetail.PartyID=acc.ID
            //left join tblcity city on acc.CityID=city.ID
            //Where main.ArrivalDate=@date and 
            //AccountTitle not like N'نقد سیل'
            //Order by sdetail.ID";
            //            var dt4 = General.FetchRecords(sql, new { date = _date });
            //            //Merge DataTables
            //            dtBanamMaster = dt1.Copy();
            //            foreach (DataRow row in dt2.Rows)
            //            {
            //                dtBanamMaster.ImportRow(row);
            //            }
            //            foreach (DataRow row in dt3.Rows)
            //            {
            //                dtBanamMaster.ImportRow(row);
            //            }
            //            foreach (DataRow row in dt4.Rows)
            //            {
            //                dtBanamMaster.ImportRow(row);
            //            } 
            #endregion
            sql=$@"Select * from vw_BanamRokar Where EntryDate='{_date:yyyy-MM-dd}'";
            dtBanamMaster = General.FetchRecords(sql, null);
            //Set DataSource for Subreport
            totalbanam = dtBanamMaster.Compute("Sum(Amount)", string.Empty) is DBNull ? 0 : Convert.ToDecimal(dtBanamMaster.Compute("Sum(Amount)", string.Empty));
            var subreport = new rokarDetails("بنام")
            {
                DataSource = dtBanamMaster,
            };
            this.xrSubreport2.ReportSource = subreport;
            GetTotal();
        }

        private void CollectJamaEntries(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Jama Report
            string sql = "";
            #region Old Version
            //Collecting Data
            //            sql = $@"Select AccountTitle,Narration,Sum(CreditAmount) as 'Amount' from vw_BankEntries Where VoucherDate=@date and CreditAmount<>0 and AccountID in (Select ID from vwBankAccounts) Group By AccountTitle,Narration";
            //            var dt1 = General.FetchRecords(sql, new { date = _date });
            //            sql = $@"Select AccountTitle,Narration,Sum(CreditAmount) as 'Amount' from vwTrx
            //Where 1=1 and VoucherType=1 and CreditAmount<>0
            //and VoucherDate=@date
            //Group By AccountTitle,Narration";
            //            var dt2 = General.FetchRecords(sql, new { date = _date });
            //            sql = $@"Select AccountTitle,'' as Narration,Sum(CreditAmount) as 'Amount' from vwTrx
            //Where 1=1 and  CreditAmount<>0 and AccountID in (Select ID From DetailAccounts Where MasterID=2)
            //and VoucherDate=@date
            //Group by AccountTitle";
            //            var dt3 = General.FetchRecords(sql, new { date = _date });
            //            sql = $@"Select AccountTitle,Narration,CreditAmount as Amount from (Select * from vwTrx
            //Where VoucherType=4 and CreditAmount<>0
            //and VoucherDate=@date) tbl 
            //where MasterAccount in (Select AccountTitle from MasterAccounts where ID=4)";
            //            var dt4 = General.FetchRecords(sql, new { date = _date });


            //            //combine
            //            dtJamaMaster = dt1.Copy();
            //            foreach (DataRow row in dt2.Rows)
            //            {
            //                dtJamaMaster.ImportRow(row);
            //            }
            //            foreach (DataRow row in dt3.Rows)
            //            {
            //                dtJamaMaster.ImportRow(row);
            //            }
            //            foreach (DataRow row in dt4.Rows)
            //            {
            //                dtJamaMaster.ImportRow(row);
            //            } 
            #endregion
            sql = $@"Select * from vw_JamaRokar Where EntryDate='{_date:yyyy-MM-dd}'";
             dtJamaMaster = General.FetchRecords(sql, null);
            totaljama = dtJamaMaster.Compute("Sum(Amount)", string.Empty) is DBNull ? 0 : Convert.ToDecimal(dtJamaMaster.Compute("Sum(Amount)", string.Empty));
            var subreport = new rokarDetails("جمع")
            {
                DataSource = dtJamaMaster,
            };
            this.xrSubreport1.ReportSource = subreport;
            GetTotal();
        }


    }
}
