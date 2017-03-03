using System;

namespace darussalambd.Models
{
    public  class tbl_DarussalamMobileCart
    {

        public int Id { get; set; }
        public string OrderId { get; set; }
        public int? CUstomerId { get; set; }
        public int? BookId { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int? Qty { get; set; }
        public decimal? UnitTotal { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? SubmitStatus { get; set; }
        public bool? ProcessStatus { get; set; }
        
    }
}
