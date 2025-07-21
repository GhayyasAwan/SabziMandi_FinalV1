using System;

namespace MandiPOS.CLasses
{
    public class vw_SubpartiesSale
    {
        public DateTime ArrivalDate { get; set; }

        public int ArrivalNo { get; set; }

        public int PartyID { get; set; }

        public string AccountTitle { get; set; }

        public string marka { get; set; }

        public decimal Remaining { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal EndBalance { get; set; }
        public string State { get { return Credit - Debit <= 0 ? "بنام" : "جمع"; } }


    }
}
