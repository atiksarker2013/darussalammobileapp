using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darussalambd.Models
{
  public  class tbl_DarussalamMobileUser
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
