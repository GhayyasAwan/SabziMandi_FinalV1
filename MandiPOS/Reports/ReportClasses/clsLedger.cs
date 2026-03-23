using System;

namespace MandiPOS.Reports.ReportClasses
{
    public class clsLedger
    {
        public DateTime VoucherDate { get; set; }
        public int TrxType { get; set; }
        public int VoucherType { get; set; }
        public  string VoucherTitle 
        { 
            get 
            {
                switch (TrxType)
                {
                    case 0:
                        return "بنام ووچر"; 
                    case 1:
                        return "جمع ووچر"; 
                    case 2:
                        return "جنرل ووچر";
                    case 3:
                        return "بیج ووچر";
                    case 5:
                        return "باردانہ ووچر";
                    case 4:
                        return "فروخت ووچر"; 
                    case -1: return "اوپننگ";
                    default:
                        return "";
                }
            } 
        }
        public string BillNo { get; set; }
        public string Narration { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string Status
        {
            get
            {
                if (Balance == 0)
                {
                    return "";
                }
                else if (Balance > 0)
                {
                    return "بنام";
                }
                else
                {
                    return "جمع";
                }
            }
        }
    }
}
