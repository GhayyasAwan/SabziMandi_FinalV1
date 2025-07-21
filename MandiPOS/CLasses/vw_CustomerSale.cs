using System;

namespace MandiPOS.CLasses
{
    public class vw_CustomerSale
    {

        public DateTime ArrivalDate { get; set; }

        public int ArrivalNo { get; set; }

        public string VendorName { get; set; }

        public string CustomerName { get; set; }

        public string ItemTitle { get; set; }

        public decimal ItemQty { get; set; }

        public decimal ItemWeight { get; set; }

        public decimal CustomerRate { get; set; }

        public decimal CustomerAmount { get; set; }

        public decimal LagaAmount { get; set; }
        public decimal FinalAmount { get { return CustomerAmount + LagaAmount; } }

    }
}
