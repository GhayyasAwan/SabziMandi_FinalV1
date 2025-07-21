using System;

namespace MandiPOS.CLasses
{
    public class vw_CommissionReport
    {
        public DateTime? ArrivalDate { get; set; }

        public int PartyID { get; set; }

        public long AccountCode { get; set; }

        public string AccountTitle { get; set; }

        public decimal CommissionAmount { get; set; }

    }
}
