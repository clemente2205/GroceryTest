using System;
using System.Collections.Generic;

#nullable disable

namespace OneSevenTest.Models
{
    public partial class TblProduct
    {
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
