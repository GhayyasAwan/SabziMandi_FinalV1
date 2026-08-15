using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class usp_ItemRecordViaAgreementID
    {
        public string ItemTitle { get; set; }
        public decimal Qty { get; set; }
        public static List<usp_ItemRecordViaAgreementID> GetData(int AgreementID)
        {
            using (var db = new db())
            {
                return db.Query<usp_ItemRecordViaAgreementID>($"Exec usp_ItemRecordViaAgreementID {AgreementID}").ToList();
            }
        }
    }
}
