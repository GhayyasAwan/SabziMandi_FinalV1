

using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class clsStock
    {
        public int SourceID { get; set; }
        public string Title { get; set; }
        public decimal Qty { get; set; }
        public decimal Weight { get; set; }
        public List<clsStock> GetStock(int ItemID)
        {
            string sql = $@"SELECT  StockSupplierID as SourceID, ItemID, acc.AccountTitle as Title,
                SUM(AdjustedQty) AS Qty, SUM(AdjustedWeight) AS Weight 
               FROM v_BardanaStockHistory 
			   left join DetailAccounts acc on StockSupplierID=ID
                WHERE ItemID = {ItemID}
                GROUP BY StockSupplierID,AccountTitle, ItemID 
                HAVING SUM(AdjustedQty) <> 0 OR SUM(AdjustedWeight) <> 0;";
            return new db().Query<clsStock>(sql).ToList();
        }
    }
}
