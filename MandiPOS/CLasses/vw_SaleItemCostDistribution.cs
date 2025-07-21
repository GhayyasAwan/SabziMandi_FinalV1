using System;
using System.Linq;

namespace MandiPOS.CLasses
{
    public class vw_SaleItemCostDistribution
    {
        public int ID { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string MonthTag { get; set; }
        public int ItemID { get; set; }
        public string ItemTitle
        {
            get
            {
                return SQL.GetAllItems($"Where ID='{ItemID}'").FirstOrDefault()?.ItemTitle;
            }
        }
        public decimal Laga { get; set; }
        public decimal Commission { get; set; }
        public decimal Mazdoori { get; set; }
        public decimal Munshiana { get; set; }
        public decimal TotalAmount
        {
            get
            {
                return Laga + Commission + Mazdoori + Munshiana;
            }
        }
        public string UrduMonthName
        {
            get
            {
                if (string.IsNullOrEmpty(MonthTag))
                {
                    return string.Empty;
                }
                var parts = MonthTag.Split('-');
                if (parts.Length != 2)
                {
                    return MonthTag;
                }
                string englishMonth = parts[0];
                string year = parts[1];
                string urduMonth = englishMonth;
                switch (englishMonth.ToLower())
                {
                    case "jan": urduMonth = "جنوری"; break;
                    case "feb": urduMonth = "فروری"; break;
                    case "mar": urduMonth = "مارچ"; break;
                    case "apr": urduMonth = "اپریل"; break;
                    case "may": urduMonth = "مئی"; break;
                    case "jun": urduMonth = "جون"; break;
                    case "jul": urduMonth = "جولائی"; break;
                    case "aug": urduMonth = "اگست"; break;
                    case "sep": urduMonth = "ستمبر"; break;
                    case "oct": urduMonth = "اکتوبر"; break;
                    case "nov": urduMonth = "نومبر"; break;
                    case "dec": urduMonth = "دسمبر"; break;
                    default:
                        urduMonth = englishMonth; break;
                }
                return $"{urduMonth}{year}";
            }
        }
    }
}
