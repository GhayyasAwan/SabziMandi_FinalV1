using Dapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class tblSecurity
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public static tblSecurity Get
        {
            get
            {
                return new db().GetLimit<tblSecurity>(1).FirstOrDefault() ?? new tblSecurity();
            }
        }

        internal static void Save(tblSecurity sec)
        {
            string sql = $"Update tblSecurity set p1='{sec.P1}',p2='{sec.P2}',p3='{sec.P3}'";
            new db().Execute(sql);
        }
    }
}
