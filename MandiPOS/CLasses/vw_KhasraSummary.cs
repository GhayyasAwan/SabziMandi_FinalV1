using System;
using System.ComponentModel;

namespace MandiPOS.CLasses
{
    public class vw_KhasraSummary
    {
        [Browsable(false)]
        public DateTime Date { get; set; }
        [Browsable(false)]
        public int PartyID { get; set; }
        [DisplayName("اکاؤنٹ کوڈ")]
        public long AccountCode { get; set; }
        [DisplayName("نام گاہک")]
        public string AccountTitle { get; set; }
        [DisplayName("تعداد")]
        public decimal TotalQty { get; set; }
        [DisplayName("وزن")]
        public decimal TotalWeight { get; set; }
        [DisplayName("رقم")]
        public decimal TotalCustomerAmount { get; set; }
        [DisplayName("لاگا")]
        public decimal TotalLagaAmount { get; set; }
        [DisplayName("صافی رقم")]
        public decimal GrandTotalAmount { get { return TotalCustomerAmount + TotalLagaAmount; } }
        [Browsable(false)]
        public decimal TotalAmount { get; set; }
        [Browsable(false)]
        public int SortOrder { get; set; }

    }
}
