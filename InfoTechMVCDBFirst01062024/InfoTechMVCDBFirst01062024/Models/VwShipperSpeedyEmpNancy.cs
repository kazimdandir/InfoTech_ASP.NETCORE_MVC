using System;
using System.Collections.Generic;

namespace InfoTechMVCDBFirst01062024.Models
{
    public partial class VwShipperSpeedyEmpNancy
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerCompanyName { get; set; } = null!;
        public string ShipperCompanyName { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
