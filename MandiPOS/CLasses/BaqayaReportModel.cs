using Dapper;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using static MandiPOS.SQL;

namespace MandiPOS.CLasses
{
    public class BaqayaReportModel
    {
        [DisplayName("نام پارٹی")]
        public string PartyTitle { get; set; }
        [DisplayName("جمع")]
        public decimal Jama { get; set; }
        [DisplayName("بنام")]
        public decimal Banam { get; set; }
        [DisplayName("بیلنس")]
        public decimal EndBalance { get; set; }
        public List<BaqayaReportModel> GetRecords(int Type, DateTime FromDate, DateTime ToDate)
        {
            List<BaqayaReportModel> records = new db().Query<BaqayaReportModel>("sp_GetBaqayaReport", new { Type = Type, FromDate = FromDate, ToDate = ToDate }, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return records;
        }
    }
}
