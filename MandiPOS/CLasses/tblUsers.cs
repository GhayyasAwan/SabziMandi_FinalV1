using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandiPOS.CLasses
{
    public class tblUsers
    {
        [Key]
        
        public int UserID { get; set; }
        public string UserName { get; set; }
       
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
    }


}
