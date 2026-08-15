using System;
using System.ComponentModel;

namespace MandiPOS.CLasses
{
    public class vw_BardanaLedger
    {
        [Browsable(false)]
        public int VoucherID { get; set; }
        [DisplayName("ووچر نمبر")]
        public int VoucherNo { get; set; }
        [DisplayName("تاریخ")]
        public DateTime Date { get; set; }
        [Browsable(false)]
        public int itemid { get; set; }
        [Browsable(false)]

        public int AccountID { get; set; }
        [DisplayName("نام کھاتہ")]
        public string AccountTitle { get; set; }
        [DisplayName("نام اشیاء")]
        public string ItemTitle { get; set; }
        [DisplayName("ریٹ")]
        public decimal ItemRate { get; set; }
        [DisplayName("تعداد")]
        public decimal ItemQty { get; set; }
        [DisplayName("وزن")]
        public decimal ItemWeight { get; set; }
        [DisplayName("رقم آمد")]
        public decimal CreditAmount { get; set; }
        [DisplayName("رقم نکاس")]
        public decimal DebitAmount { get; set; }
        [DisplayName("بیلنس")]
        public decimal RunningBalance { get; set; }
    }
}
