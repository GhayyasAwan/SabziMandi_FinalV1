using Dapper;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

using static MandiPOS.SQL;

namespace MandiPOS.CLasses
{
    public class DetailAccounts
    {
        [Key]

        public int ID { get; set; }
        [DisplayName("کوڈ")]
        public long AccountCode { get; set; }

        public int MasterID { get; set; }
        [DisplayName("نام پارٹی")]
        public string AccountTitle { get; set; }
        [DisplayName("رابطہ نمبر")]
        public string Contact { get; set; }
        [DisplayName("شہر")]
        public int CityID { get; set; } = General.MultanCityID;
        [DisplayName("سابقہ جمع")]
        public decimal OpCredit { get; set; }
        [DisplayName("سابقہ بنام")]
        public decimal OpDebit { get; set; }
        [DisplayName("تفصیل")]
        public string Remarks { get; set; }
        [DisplayName("بیلنش حد")]
        public decimal CreditLimit { get; set; }
        [DisplayName("کمیشن")]
        public decimal Commission { get; set; }

        public int? RefrenceType { get; set; }
        public byte[] CustomLabel { get; set; }

        public int? RefrenceID { get; set; }
        [DisplayName("معرفت")]
        public string RefName { get; set; }

        internal static DetailAccounts GetAccountByID(int accountID)
        {
            return new db().Get<DetailAccounts>(accountID);
        }
    }
    public class DetailAccountView
    {
        [Key]

        public int ID { get; set; }
        [DisplayName("کوڈ")]
        public long AccountCode { get; set; }
        [DisplayName("نام پارٹی")]
        public string AccountTitle { get; set; }
        [DisplayName("رابطہ نمبر")]
        public string Contact { get; set; }
        [DisplayName("شہر")]
        public string City { get; set; }
        [DisplayName("سابقہ جمع")]
        public decimal OpCredit { get; set; }
        [DisplayName("سابقہ بنام")]
        public decimal OpDebit { get; set; }
        [DisplayName("تفصیل")]
        public string Remarks { get; set; }
        [DisplayName("بیلنس حد")]
        public decimal CreditLimit { get; set; }
        [DisplayName("کمیشن")]
        public decimal Commission { get; set; }
        [DisplayName("معرفت")]
        public string RefName { get; set; }

    }
    public static class DetailAccountService
    {

        public static List<DetailAccountView> BankCashAccounts()
        {
            string sql = $@"Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
Where acc.MasterID in (Select AccountID From BankCashAccounts) ORDER BY 
  CASE 
    WHEN AccountTitle LIKE N'‎کیش روکڑ' THEN 0 
    ELSE 1 
  END,
  ID";
            return new db().Query<DetailAccountView>(sql).ToList();
        }
        public static IEnumerable<DetailAccountView> PartyAccounts()
        {
            string sql = $@"Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID";
            return new db().Query<DetailAccountView>(sql);
        }
        public static List<DetailAccountView> VendorAccounts()
        {
            string sql = $@"Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
Where acc.MasterID =4";
            return new db().Query<DetailAccountView>(sql).ToList();
        }
        public static List<DetailAccountView> CustomerAccounts()
        {
            string sql = $@"Select acc.ID,
acc.AccountCode,
acc.AccountTitle,
acc.Contact,
c.CityName as 'City',
acc.OpCredit,
acc.OpDebit,
acc.Remarks, acc.CreditLimit, acc.Commission, acc.RefName
from 
detailAccounts acc
left join tblCity c on acc.cityID=c.ID
Where acc.MasterID =7";
            return new db().Query<DetailAccountView>(sql).ToList();
        }
        public static IEnumerable<DetailAccounts> GetAccountsList(int MasteriID = 0)
        {
            return new db().GetList<DetailAccounts>(MasteriID > 0 ? $" Where MasterID = {MasteriID}" : "").ToList();
        }
        public static IEnumerable<DetailAccountView> GetAccountsViewList(int MasteriID = 0)
        {
            return new db().Query<DetailAccountView>($"Exec GetDetailAccount '{MasteriID}'").ToList();
        }
        public static IEnumerable<DetailAccountView> GetAccountsViewList()
        {
            return new db().Query<DetailAccountView>($"Exec GetDetailAccount").ToList();
        }
        public static IEnumerable<DetailAccountView> GetRefferalsList()
        {
            return new db().Query<DetailAccountView>($"Exec GetReferral").ToList();
        }
        public static IEnumerable<DetailAccountView> GetSubPartiesAccountList()
        {
            return new db().Query<DetailAccountView>($"Exec GetSubParties").ToList();
        }
        public static DetailAccounts GetDetailAccountByID(int id)
        {
            return new db().Get<DetailAccounts>(id) ?? new DetailAccounts();
        }
        public static string GenerateNextAccountCode(int masterId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string prefix = masterId == 10 ? (masterId + 91).ToString() : masterId.ToString();
            string query = $"SELECT MAX(AccountCode) FROM DetailAccounts WHERE AccountCode LIKE @prefix + '%' and MasterID={masterId}";

            bool createdConnection = false;
            string maxCode = null;

            try
            {
                if (connection == null)
                {
                    connection = new db(); // Replace with your actual connection string
                    connection.Open();
                    createdConnection = true;
                }

                maxCode = connection.ExecuteScalar<string>(
                    query,
                    new { prefix },
                    transaction: transaction
                );
            }
            finally
            {
                if (createdConnection && connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            string nextCode;

            if (!string.IsNullOrEmpty(maxCode))
            {
                int numericPart = int.Parse(maxCode.Substring(prefix.Length));
                int nextNumericPart = numericPart + 1;

                // Preserve digit length
                nextCode = prefix + nextNumericPart.ToString("D" + (maxCode.Length - prefix.Length));
            }
            else
            {
                nextCode = prefix + "0001";
            }

            return nextCode;
        }
        public static bool SaveDetailAccount(DetailAccounts acc)
        {
            try
            {
                using (var db = new db())
                {
                    using (var trx = db.BeginTransaction())
                    {
                        try
                        {
                            if (acc.ID > 0)
                            {
                                db.Update<DetailAccounts>(acc, trx);
                            }
                            else
                            {
                                acc.AccountCode = GenerateNextAccountCode(acc.MasterID, db, trx).toInt();
                                db.Insert<DetailAccounts>(acc, trx);
                            }
                            trx.Commit();
                            return true;
                        }
                        catch
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e.ExcError("Saving Detail Account...");
            }
        }

        public static bool DeleteDetailAccount(int recordId)
        {
            using (var db = new db())
            {
                using (var trx = db.BeginTransaction())
                {
                    var records = db.GetList<DetailAccounts>($" where RefrenceID={recordId}", transaction: trx).ToList();
                    if (records.Count > 0)
                    {
                        trx.Rollback();
                        throw new Exception("یہ کھاتہ کسی دوسرے ریکارڈ سے منسلک ہے۔ براہ کرم پہلے اس کو منسلک ریکارڈ سے ہٹا دیں۔");
                    }
                    db.Delete<DetailAccounts>(recordId, transaction: trx);
                    trx.Commit();
                    return true;
                }
            }
        }

        internal static object GetAllPartyNames()
        {
            throw new NotImplementedException();
        }

        internal static void SaveCustomLabel(int iD, byte[] bmpArray)
        {
            try
            {
                using (var db = new db())
                {
                    string sql = "Update DetailAccounts Set CustomLabel=@CustomLabel Where ID=@id";
                    db.Execute(sql, new { id = iD, CustomLabel = bmpArray });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
