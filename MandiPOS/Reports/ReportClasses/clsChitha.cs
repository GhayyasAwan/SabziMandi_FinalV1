using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.Reports.ReportClasses
{
    public  class clsChitha
    {
        public int ID { get; set; }
        public int MasterID { get; set; }
        public string AccountTitle { get; set; }
        public string MasterAccount { get; set; }
        public string RefName { get; set; }
        public string Contact { get; set; }
        public string CityName { get; set; }
        public decimal EndBalance { get; set; }
        public string OldAccountCode { get; set; }
        public bool IsActive { get; set; }
    }
}
