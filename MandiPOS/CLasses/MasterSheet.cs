using System;

namespace MandiPOS.CLasses
{
    public class MasterSheet
    {
        public DateTime ArrivalDate { get; set; }
        public string ArrivalNo { get; set; }
        public string ItemTitle { get; set; }
        public decimal ItemQty { get; set; }
        public decimal Commission { get; set; }
        public decimal Mazdoori { get; set; }
        public decimal Munshiana { get; set; }
        public decimal PartyAmount { get; set; }
        public decimal CustomerAmount { get; set; }
        public decimal BaqayaSale { get { return CustomerAmount - PartyAmount; } }
        public decimal TotalExpenses { get { return Commission + Mazdoori + Munshiana; } }
        public decimal Karaya { get; set; }
        public decimal NetPaid { get; set; }
        public decimal OtherExpenses { get { return Karaya + NetPaid; } }
        public decimal NetAmount { get { return PartyAmount - TotalExpenses - Karaya - NetPaid; } }
        public int PartyID { get; set; }
        public string Marka { get; set; }
    }

}
