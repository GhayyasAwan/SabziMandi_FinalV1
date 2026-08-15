using DevExpress.Data.Mask.Internal;

using System;
using System.ComponentModel.DataAnnotations;

namespace MandiPOS.CLasses
{
    public class vw_vendorSale
    {
        [Key]

        public DateTime ArrivalDate { get; set; }

        public int ArrivalNo { get; set; }
        public int PartyID { get; set; }

        public string AccountTitle { get; set; }

        public string ItemDetails { get; set; }

        public string TotalQty { get; set; }

        public string TotalLaga { get; set; }

        public decimal CommissionAmount { get; set; }

        public decimal MazdooriAmount { get; set; }

        public decimal MunshianaAmount { get; set; }

        public decimal KarayaAmount { get; set; }
        public decimal Expenses
        {
            get
            {
                return CommissionAmount + MazdooriAmount + MunshianaAmount ;
            }
        }

        public decimal SaleAmount2 { get; set; }

        public decimal PaidAmount { get; set; }
        public decimal TotalPaidAmount { get 
            {
                return PaidAmount + KarayaAmount;
            } }
        public decimal NetAmount
        {
            get
            {
                return SaleAmount2 - Expenses - TotalPaidAmount;
            }
        }
        public decimal Debit { get { return NetAmount<=0 ? Math.Abs(NetAmount) : 0; } }
        public decimal Credit { get { return NetAmount > 0 ? Math.Abs(NetAmount) : 0; } }
        public decimal EndBalance { get { return Math.Abs(Debit - Credit); } }
        public string State { get { return RunningTotal>=0?"جمع":"بنام"; } }
        public decimal RunningTotal { get; set; }
    }
}
