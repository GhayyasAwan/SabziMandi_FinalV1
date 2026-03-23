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
    public class tblItems
    {
        [Key]

        public int ID { get; set; }
        [DisplayName("کوڈ")]
        public int Code { get; set; }
        [DisplayName("اشیاء کا نام")]
        public string ItemTitle { get; set; }
        [DisplayName("اشیاء کی قسم")]
        public string ItemType { get; set; }
        [DisplayName("لاگا")]
        public decimal ChwanniRate { get; set; }
        [DisplayName("کرایہ")]
        public decimal fairRate { get; set; }

        public decimal MarketRate { get; set; }
        [DisplayName("مزدوری")]
        public decimal LabourRate { get; set; }

        public decimal PhonePostRate { get; set; }

        public decimal Deposit { get; set; }

        public decimal DastiCash { get; set; }

    }
    public static class ItemService
    {
        public static List<tblItems> GetItems(string itemTypes)
        {
            string sql = $@"Select * from tblItems Where ItemType in ({itemTypes})";
            return new db().Query<tblItems>(sql).ToList();
        }

        internal static int GetItemStock(int v)
        {
            string sql = $"Select Sum(Cr-Dr) as Stock From [vwStockFlo] Where ItemID={v}";
            return new db().ExecuteScalar<decimal>(sql).toInt();
        }

        internal static int GetItemWeightStock(int v)
        {
            string sql = $"Select Sum(wtCr-wtDr) as wtStock From [vwStockFlo] Where ItemID={v}";
            return new db().ExecuteScalar<decimal>(sql).toInt();
        }
    }
}
