using Dapper;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MandiPOS.CLasses
{
    public class Vouchers
    {
        [Key]

        public int VoucherID { get; set; }

        public string VoucherNo { get; set; }

        public DateTime VoucherDate { get; set; }

        public string VoucherType { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<VoucherCart> Entries { get; set; } = new List<VoucherCart>();
        public List<BardanaCart> BardanaEntries { get; set; } = new List<BardanaCart>();
        public IEnumerable<JVCart> JVEntries { get; set; } = new List<JVCart>();

    }
    public class JVEntries
    {
        [Key]

        public int ID { get; set; }

        public int VoucherID { get; set; }

        public int AccountID { get; set; }

        public string Narration { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }
        public decimal EnteredBy { get; set; }


    }
    public class JVCart
    {
        [Browsable(false)]
        public int AccountID { get; set; }
        [DisplayName("کوڈ")]
        public string AccountCode { get; set; }
        [DisplayName("نام پارٹی")]
        public string PartyTitle { get; set; }
        [DisplayName("تفصیل")]
        public string Narration { get; set; }
        [DisplayName("رقم جمع")]
        public decimal DebitAmount { get; set; }
        [DisplayName("رقم بنام")]
        public decimal CreditAmount { get; set; }
        public int EnteredBy { get; set; }
        public int id { get; set; }
        public int IsCurrentUserEntry { get { return EnteredBy == General.CurrentUserID ? 1 : 0; } }
    }
    public class VoucherDetails
    {
        [Key]

        public int EntryID { get; set; }

        public int VoucherID { get; set; }
        public string Narration { get; set; }

        public int PartyID { get; set; }

        public int CashAccountID { get; set; }

        public decimal Amount { get; set; }
        public int EnteredBy { get; set; }


    }
    public class VoucherCart
    {
        public int EntryID { get; set; } = 0;
        public int index { get; set; }
        public int PartyID { get; set; }
        [DisplayName("کوڈ")]
        public string PartyCode { get; set; }
        [DisplayName("نام پارٹی")]
        public string PartyName { get; set; }
        [DisplayName("")]
        public int CashAccountID { get; set; }
        [DisplayName("کیش / بینک اکاؑنٹ")]
        public string CashAccount { get; set; }
        [DisplayName("تفصیل")]
        public string Narration { get; set; }
        [DisplayName("رقم")]
        public decimal Amount { get; set; }
        public int EnteredBy { get; set; }
        public int IsCurrentUserEntry { get { return EnteredBy == General.CurrentUserID ? 1 : 0; } }
    }
    public class BardanaCart
    {
        [Browsable(false)]
        public int ID { get; set; }
        [Browsable(false)]
        public int VoucherID { get; set; }
        [Browsable(false)]
        public int AccountID { get; set; }
        [DisplayName("کوڈ")]
        public string Code { get; set; }
        [DisplayName("نام پارٹی")]
        public string PartyName { get; set; }
        [DisplayName("تفصیل")]
        public string Narration { get; set; }
        [DisplayName("تفصیل دوم")]
        public string Narration2 { get; set; }
        [Browsable(false)]
        public int ItemID { get; set; }
        [Browsable(false)]
        public int ItemType { get; set; }
        [Browsable(false)]
        public int EntryType { get; set; }
        [DisplayName("اشیاء")]
        public string ItemName { get; set; }
        [DisplayName("تعداد")]
        public decimal ItemQty { get; set; }
        [DisplayName("وزن")]
        public decimal ItemWeight { get; set; }
        [DisplayName("ریٹ")]
        public decimal ItemRate { get; set; }
        [DisplayName("رقم بنام")]
        public decimal DebitAmount { get; set; }
        [DisplayName("رقم جمع")]
        public decimal CreditAmount { get; set; }
        [Browsable(false)]
        public string ItemDescription { 
            get 
            {
                if (ItemWeight == 0)
                {
                    return $"{ItemName} => {ItemQty} x {ItemRate}";
                }
                else
                {
                    return $"{ItemName} تعداد:{ItemQty}{(ItemWeight == 0 ? string.Empty : $" وزن:{ItemWeight:#,#.##} کلو")}  , ریٹ:{ItemRate}";
                }
            } 
        }
        public int EnteredBy { get; set; }
        public int IsCurrentUserEntry { get { return EnteredBy == General.CurrentUserID ? 1 : 0; } }
    }
    public class VoucherBardanaDetails
    {
        [Key]

        public int ID { get; set; }

        public int VoucherID { get; set; }

        public int AccountID { get; set; }
        public string Narration { get; set; }

        public int ItemID { get; set; }

        public decimal ItemQty { get; set; }
        public decimal ItemWeight { get; set; }
        public decimal ItemRate { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

        public string ItemDescription { get; set; }
        public int EnteredBy { get; set; }

    }
    public static class VoucherService
    {
        public static string NextVocuherNo(int vtype=1)
        {
                return new db().ExecuteScalar<string>($"Select Cast(ISNULL(Max(VoucherNo),0)+1 as nvarchar) as 'NextCode' from Vouchers Where VoucherType='{vtype}'");
        }
        public static Vouchers GetVoucher(int vtype = 0, DateTime? date = null)
        {
            DateTime targetDate = date?.Date ?? DateTime.Now.Date;

            using (var db = new db())
            {
                var query = $"Select * from Vouchers  WHERE VoucherType = '{vtype}' AND VoucherDate = '{targetDate:yyyy-MM-dd}';";
                var voucher = db.Query<Vouchers>(query, new { VoucherType = vtype, VoucherDate = targetDate }).ToList().FirstOrDefault() ?? new Vouchers() { VoucherType = vtype.ToString(), VoucherDate = targetDate, VoucherNo=NextVocuherNo(vtype)};

                if (voucher.VoucherID != 0) // or != null depending on type
                {
                    string sql = $@"Select vd.EntryID,
vd.PartyID,
p.AccountCode as 'PartyCode',
p.AccountTitle as 'PartyName',
CashAccountID,
cp.AccountTitle as 'CashAccount',
vd.Narration,
vd.Amount, vd.EnteredBy
from voucherDetails vd
left join DetailAccounts cp on vd.cashAccountID=cp.ID
left join DetailAccounts p on vd.PartyID=p.ID Where VoucherID=@VoucherID";
                    voucher.Entries = db.Query<VoucherCart>(sql, new { VoucherID = voucher.VoucherID }).ToList();
                    if (voucher.VoucherType == 3.ToString()||voucher.VoucherType == 5.ToString())
                    {
                        sql = $@"Select bd.ID, bd.VoucherID,bd.accountID,acc.AccountCode as 'Code',
acc.AccountTitle as 'PartyName',bd.Narration,p.id as 'ItemID',p.ItemTitle as 'ItemName', 
bd.ItemQty,bd.ItemRate,bd.ItemWeight,bd.DebitAmount,bd.CreditAmount,bd.ItemDescription,bd.EnteredBy
from VoucherBardanaDetails bd
left join tblItems p on bd.itemID=p.ID
left join DetailAccounts acc on bd.accountiD=acc.ID
Where VoucherID=@VoucherID Order by bd.id desc";
                        voucher.BardanaEntries = db.Query<BardanaCart>(sql, new { VoucherID = voucher.VoucherID }).ToList();
                    }
                    else
                    {
                        voucher.BardanaEntries = new List<BardanaCart>();
                    }
                    if (voucher.VoucherType == 2.ToString()) //Journal Voucher
                    {
                        sql = "Select jv.id, jv.AccountID,acc.AccountTitle as 'PartyTitle',acc.AccountCode,jv.Narration,jv.DebitAmount,jv.CreditAmount\r\nfrom jvEntries jv left join DetailAccounts acc on jv.AccountID=acc.ID Where jv.VoucherID=@VoucherID order by jv.ID Desc";
                        voucher.JVEntries = db.Query<JVCart>(sql, new { VoucherID = voucher.VoucherID }).OrderByDescending(x => x.id);
                    }

                    else
                    {
                        voucher.JVEntries = new List<JVCart>(); ;
                    }
                }
                else
                {
                    voucher.Entries = new List<VoucherCart>();
                    voucher.BardanaEntries = new List<BardanaCart>();
                }

                return voucher;
            }
        }
        public static Vouchers GetVoucherById(int vtype = 0, int id=0)
        {
            

            using (var db = new db())
            {
                var query = "Select Top 1 * from Vouchers  WHERE VoucherType = @VoucherType AND VoucherID = @VoucherID";
                var voucher = db.Query<Vouchers>(query, new { VoucherType = vtype, VoucherID = id }).ToList().FirstOrDefault() ?? new Vouchers() { VoucherType = vtype.ToString(), VoucherDate = DateTime.Now.Date, VoucherNo=NextVocuherNo(vtype) };

                if (voucher.VoucherID != 0) // or != null depending on type
                {
                    string sql = $@"Select vd.EntryID,
vd.PartyID,
p.AccountCode as 'PartyCode',
p.AccountTitle as 'PartyName',
CashAccountID,
cp.AccountTitle as 'CashAccount',
vd.Narration,
vd.Amount, vd.EnteredBy
from voucherDetails vd
left join DetailAccounts cp on vd.cashAccountID=cp.ID
left join DetailAccounts p on vd.PartyID=p.ID Where VoucherID=@VoucherID";
                    voucher.Entries = db.Query<VoucherCart>(sql, new { VoucherID = voucher.VoucherID }).ToList();
                    if (voucher.VoucherType == 3.ToString())
                    {
                        sql = $@"Select bd.ID, bd.VoucherID,bd.accountID,acc.AccountCode as 'Code',
acc.AccountTitle as 'PartyName',bd.Narration,p.id as 'ItemID',p.ItemTitle as 'ItemName', 
bd.ItemQty,bd.ItemRate,bd.DebitAmount,bd.CreditAmount,bd.ItemDescription,bd.EnteredBy
from VoucherBardanaDetails bd
left join tblItems p on bd.itemID=p.ID
left join DetailAccounts acc on bd.accountiD=acc.ID
Where VoucherID=@VoucherID Order by bd.id desc";
                        voucher.BardanaEntries = db.Query<BardanaCart>(sql, new { VoucherID = voucher.VoucherID }).ToList();
                    }
                    else
                    {
                        voucher.BardanaEntries = new List<BardanaCart>();
                    }
                    if (voucher.VoucherType == 2.ToString()) //Journal Voucher
                    {
                        sql = "Select jv.id, jv.AccountID,acc.AccountTitle as 'PartyTitle',acc.AccountCode,jv.Narration,jv.DebitAmount,jv.CreditAmount\r\nfrom jvEntries jv left join DetailAccounts acc on jv.AccountID=acc.ID Where jv.VoucherID=@VoucherID order by jv.ID Desc";
                        voucher.JVEntries = db.Query<JVCart>(sql, new { VoucherID = voucher.VoucherID }).OrderByDescending(x => x.id);
                    }

                    else
                    {
                        voucher.JVEntries = new List<JVCart>(); ;
                    }
                }
                else
                {
                    voucher.Entries = new List<VoucherCart>();
                    voucher.BardanaEntries = new List<BardanaCart>();
                }
                return voucher;
            }
        }
        public static Vouchers GetVoucherByNo(int vtype = 0, int id = 0)
        {


            using (var db = new db())
            {
                var query = "Select Top 1 * from Vouchers  WHERE VoucherType = @VoucherType AND VoucherNo = @VoucherNo";
                var voucher = db.Query<Vouchers>(query, new { VoucherType = vtype, VoucherNo = id }).ToList().FirstOrDefault(); 
                    if(voucher == null)
                    {
                       return GetVoucher(vtype, null);
                    }
                if (voucher.VoucherID != 0) // or != null depending on type
                {
                    string sql = $@"Select vd.EntryID,
vd.PartyID,
p.AccountCode as 'PartyCode',
p.AccountTitle as 'PartyName',
CashAccountID,
cp.AccountTitle as 'CashAccount',
vd.Narration,
vd.Amount, vd.EnteredBy
from voucherDetails vd
left join DetailAccounts cp on vd.cashAccountID=cp.ID
left join DetailAccounts p on vd.PartyID=p.ID Where VoucherID=@VoucherID";
                    voucher.Entries = db.Query<VoucherCart>(sql, new { VoucherID = voucher.VoucherID }).ToList();
                    if (voucher.VoucherType == 3.ToString()|| voucher.VoucherType == 5.ToString())
                    {
                        sql = $@"Select bd.ID, bd.VoucherID,bd.accountID,acc.AccountCode as 'Code',
acc.AccountTitle as 'PartyName',bd.Narration,p.id as 'ItemID',p.ItemTitle as 'ItemName', 
bd.ItemQty,bd.ItemRate,bd.DebitAmount,bd.CreditAmount,bd.ItemDescription,bd.EnteredBy
from VoucherBardanaDetails bd
left join tblItems p on bd.itemID=p.ID
left join DetailAccounts acc on bd.accountiD=acc.ID
Where VoucherID=@VoucherID Order by bd.id desc";
                        voucher.BardanaEntries = db.Query<BardanaCart>(sql, new { VoucherID = voucher.VoucherID }).ToList();
                    }
                    else
                    {
                        voucher.BardanaEntries = new List<BardanaCart>();
                    }
                    if (voucher.VoucherType == 2.ToString()) //Journal Voucher
                    {
                        sql = "Select jv.id, jv.AccountID,acc.AccountTitle as 'PartyTitle',acc.AccountCode,jv.Narration,jv.DebitAmount,jv.CreditAmount\r\nfrom jvEntries jv left join DetailAccounts acc on jv.AccountID=acc.ID Where jv.VoucherID=@VoucherID order by jv.ID Desc";
                        voucher.JVEntries = db.Query<JVCart>(sql, new { VoucherID = voucher.VoucherID }).OrderByDescending(x => x.id);
                    }

                    else
                    {
                        voucher.JVEntries = new List<JVCart>(); ;
                    }
                }
                else
                {
                    voucher.Entries = new List<VoucherCart>();
                    voucher.BardanaEntries = new List<BardanaCart>();
                }
                return voucher;
            }
        }

        internal static bool SaveVoucher(Vouchers main)
        {
            try
            {
                using (var db = new db())
                {
                    using (var trx = db.BeginTransaction())
                    {
                        try
                        {
                            if (main.VoucherID == 0)
                            {
                                main.VoucherNo = db.ExecuteScalar<string>($"Select Cast(ISNULL(Max(VoucherNo),0)+1 as nvarchar) as 'NextCode' from Vouchers Where VoucherType='{main.VoucherType}'", transaction: trx);
                                db.Insert<Vouchers>(main, transaction: trx);
                            }
                            else
                            {
                                db.Update<Vouchers>(main, transaction: trx);
                            }
                            db.Execute($"Delete From VoucherDetails Where VoucherID={main.VoucherID}", transaction: trx);
                            foreach (var entry in main.Entries)
                            {
                                VoucherDetails d = new VoucherDetails()
                                {
                                    Amount = entry.Amount,
                                    Narration = entry.Narration,
                                    CashAccountID = entry.CashAccountID,
                                    PartyID = entry.PartyID,
                                    VoucherID = main.VoucherID
                                };
                                db.Insert<VoucherDetails>(d, transaction: trx);
                            }
                            db.Execute($"Delete From VoucherBardanaDetails Where VoucherID={main.VoucherID}", transaction: trx);
                            foreach (var entry in main.BardanaEntries)
                            {
                                VoucherBardanaDetails d = new VoucherBardanaDetails()
                                {
                                    AccountID = entry.AccountID,
                                    CreditAmount = entry.CreditAmount,
                                    DebitAmount = entry.DebitAmount,
                                    ID = entry.ID,
                                    ItemDescription = entry.ItemDescription,
                                    ItemID = entry.ItemID,
                                    ItemQty = entry.ItemQty,
                                    ItemRate = entry.ItemRate,
                                    Narration = entry.Narration,
                                    VoucherID = main.VoucherID
                                };
                                db.Insert<VoucherBardanaDetails>(d, transaction: trx);
                            }
                            db.Execute($"Delete From JVEntries Where VoucherID={main.VoucherID}", transaction: trx);
                            foreach (JVCart entry in main.JVEntries)
                            {
                                JVEntries jv = new JVEntries()
                                {
                                    AccountID = entry.AccountID,
                                    CreditAmount = entry.CreditAmount,
                                    DebitAmount = entry.DebitAmount,
                                    Narration = entry.Narration,
                                    VoucherID = main.VoucherID
                                };
                                db.Insert<JVEntries>(jv, transaction: trx);
                            }
                            trx.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
