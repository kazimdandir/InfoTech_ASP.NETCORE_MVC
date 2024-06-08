using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Entities
{
    public class Product
    {
        [Key] // data annotation
        public int ProductID { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; }


        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }

        [ForeignKey("Category")]
        public int CatID { get; set; }

        public virtual Category Category { get; set ; }
    }
}
