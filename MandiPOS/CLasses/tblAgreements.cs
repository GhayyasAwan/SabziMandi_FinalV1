

using Dapper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MandiPOS.CLasses
{
    public class tblAgreements
    {
        [Key]
        public int AgreementID { get; set; }
        public int PartyID { get; set; }
        [NotMapped]
        public string PartyName
        {
            get
            {
                if (PartyID == 0)
                    return "";
                else
                    using (var db = new db())
                    {
                        return db.Get<DetailAccounts>(PartyID)?.AccountTitle;
                    }
            }
        }
        [NotMapped]
        public string PartyCode
        {
            get
            {
                if (PartyID == 0)
                    return "";
                else
                    using (var db = new db())
                    {
                        return db.Get<DetailAccounts>(PartyID)?.AccountCode.ToString();
                    }
            }
        }

        [Required]
        public DateTime AgreementStartDate { get; set; } = DateTime.Now.Date;

        public DateTime? AgreementEndDate { get; set; } = null;// Nullable kyunke SQL mein NULL likha hai

        public string Remarks { get; set; }
    }
    public class tblAgreementDetails
    {
        [Key]
        public int AgreementDetailID { get; set; }

        [Required]
        public int AgreementID { get; set; }

        [Required]

        public int ItemID { get; set; }
        [NotMapped]
        [DisplayName("نام اشیاء")]
        public string ItemTitle { get { if (ItemID == 0) return ""; else return new db().Get<tblItems>(ItemID)?.ItemTitle; } }

        [MaxLength(50)]
        [DisplayName("رقبہ")]
        public string Area { get; set; }

        [ForeignKey("AgreementID")]
        public virtual tblAgreements Agreement { get; set; }
    }
    public class vwAgreements
    {
        public int AgreementID { get; set; }
        [DisplayName("معاہدہ نمبر")]
        public string AgreementNo { get; set; }
        public int? PartyID { get; set; }
        [DisplayName("پارٹی")]
        public string AccountTitle { get; set; }
        [DisplayName("تاریخ اول")]
        public DateTime AgreementStartDate { get; set; }
        [DisplayName("تاریخ دوم")]
        public DateTime? AgreementEndDate { get; set; }
        [DisplayName("تفصیلات")]
        public string Remarks { get; set; }
    }
}
