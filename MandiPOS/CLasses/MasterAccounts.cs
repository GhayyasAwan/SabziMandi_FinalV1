using Dapper;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class MasterAccounts
    {
        [Key]

        public int ID { get; set; }
        [DisplayName("عنوان کھاتہ")]

        public string AccountTitle { get; set; }
        [DisplayName("قسم کھاتہ")]
        public string AccountType { get; set; }
        public bool IsSystem { get; set; } = false;

    }
    public static class MasterAccountsService
    {
        public static List<MasterAccounts> GetMasterAccounts(string wherecluse = "")
        {
            return new db().GetList<MasterAccounts>(wherecluse).ToList();
        }
        public static bool SaveMasterAccount(MasterAccounts acc)
        {
            try
            {
                if (acc.ID > 0)
                {
                    using (var xdb = new db())
                    {
                        return xdb.Update<MasterAccounts>(acc);
                    }
                }
                else
                {
                    using (var xdb = new db())
                    {
                        xdb.Insert<MasterAccounts>(acc);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return e.ExcError("Saving Master Account...");
            }
        }
        public static bool DeleteMasterAccount(int recordId)
        {
            return new db().Delete<MasterAccounts>(recordId);
        }
    }
}
