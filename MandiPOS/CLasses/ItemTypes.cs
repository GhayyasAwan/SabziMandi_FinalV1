using DevExpress.Utils.Animation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class ItemTypes
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<ItemTypes> GetList()
        {
            var list = new List<ItemTypes>();
            list.Add(new ItemTypes() { ID = 1, Title = "سبزی" });
            list.Add(new ItemTypes() { ID = 2, Title = "فروٹ" });
            list.Add(new ItemTypes() { ID = 3, Title = "دیگر اشیاء" });
            return list;
        }
    }
}
