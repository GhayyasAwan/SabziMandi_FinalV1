using System;

namespace MandiPOS.CLasses
{
    public class vendorWiseSale
    {
        public DateTime ArrivalDate { get; set; }
        public string ArrivalNo { get; set; }

        public string VendorAccountCode { get; set; }
        public string VendorAccountFull { get; set; }
        public string marka { get; set; }

        public string CustomerAccountCode { get; set; }
        public string CustomerAccountFull { get; set; }

        public decimal ItemQty { get; set; }
        public decimal ItemWeight { get; set; }

        public decimal CustomerRate { get; set; }
        public decimal CustomerAmount { get; set; }
        public decimal LagaAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string ItemDetail { get; set; }
    }

}
