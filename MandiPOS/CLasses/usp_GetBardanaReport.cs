using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class usp_GetBardanaReport
    {
        public DateTime VoucherDate { get; set; }
        public int Vno { get; set; }
        public decimal ItemRate { get; set; }
        public decimal BanamQty { get; set; }
        public decimal JamaQty { get; set; }
        public decimal BanamRaqam { get; set; }
        public decimal JamaRaqam { get; set; }
        public string ItemTitle { get; set; }

        public static async Task<List<usp_GetBardanaReport>> GetReport(int PartyID, DateTime dateFrom, DateTime dateTo)
        {
            // 1. Dapper parameters banayein
            var parameters = new DynamicParameters();
            parameters.Add("@DateFrom", dateFrom.ToString("yyyy-MM-dd"));
            parameters.Add("@DateTo", dateTo.ToString("yyyy-MM-dd"));
            parameters.Add("@PartyID", PartyID);

            using (var connection = new db()) // Aapki DB connection method
            {
                // 2. QueryAsync mein model ka naam dein, CommandType StoredProcedure set karein
                var result = connection.Query<usp_GetBardanaReport>(
                    "usp_GetBardanaReport",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }
    }
}
