using Dapper;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class vwBaqayaSale
    {
        public DateTime ArrivalDate { get; set; }
        public int ArrivalNo { get; set; }
        public string AccountTitle { get; set; }
        public int MasterID { get; set; }
        public int PartyID { get; set; }
        public decimal ItemQty { get; set; }
        public decimal ItemWeight { get; set; }
        public decimal DiffAmount { get; set; }
        public string Narration { get; set; }
    }
    public static class vwBaqayaSaleService
    {
        public static IEnumerable<vwBaqayaSale> GetBaqayaSaleList(DateTime date1, DateTime date2, int PartyID)
        {
            using (var db = new db())
            {
                var sql = @"
SELECT *
FROM vwBaqayaSale
WHERE PartyID = @PartyID
  AND ArrivalDate >= @FromDate
  AND ArrivalDate < @ToDate";

                return db.Query<vwBaqayaSale>(sql, new
                {
                    PartyID,
                    FromDate = date1.Date,
                    ToDate = date2.Date.AddDays(1)
                });

            }
        }
    }
}
