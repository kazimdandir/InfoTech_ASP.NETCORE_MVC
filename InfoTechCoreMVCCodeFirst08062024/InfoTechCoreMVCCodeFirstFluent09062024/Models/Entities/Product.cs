using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCCodeFirstFluent09062024.Models.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }

        public int CatID { get; set; }

        public virtual Category Category { get; set; }
    }
}
