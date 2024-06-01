using System;
using System.Collections.Generic;

namespace InfoTechMVCDBFirst01062024.Models
{
    public partial class VwGetProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
