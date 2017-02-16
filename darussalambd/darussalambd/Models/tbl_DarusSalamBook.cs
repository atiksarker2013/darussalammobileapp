using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darussalambd.Models
{
  public  class tbl_DarusSalamBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public int? OutOfStock { get; set; }
        public int? InStock { get; set; }
        public string Barcode { get; set; }
        public DateTime? EntryDate { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
 

    }
}
