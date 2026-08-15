using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class tblCity
    {
        [Key]

        public int ID { get; set; }

        [DisplayName("شہر کا نام")]
        public string CityName { get; set; }

        public string CityNameEnglish { get; set; }

    }
    public class Settings
    {
        public string SettingKey { get; set; }
        public string Value { get; set; }
    }
}
