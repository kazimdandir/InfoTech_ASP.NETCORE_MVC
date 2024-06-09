using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCCodeFirstFluent09062024.Models.Entities
{
    public class Category
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
        public string Descp { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
