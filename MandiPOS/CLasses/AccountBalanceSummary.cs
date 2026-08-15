using System;

namespace MandiPOS.CLasses
{
    public class AccountBalanceSummary
    {
        public int AccountID { get; set; }
        public long AccountCode { get; set; }
        public string AccountTitle { get; set; }
        public string Contact { get; set; }

        public decimal PreviousBalance { get; set; }

        public decimal TodayDebit { get; set; }

        public decimal TodayCredit { get; set; }

        public decimal CurrentBalance { get; set; }
        public DateTime LastDate { get; set; }
    }

}
