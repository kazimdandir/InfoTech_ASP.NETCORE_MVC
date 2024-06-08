using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Entities
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }

        [MaxLength(50)]
        public string CatName { get; set; }

        [MaxLength(255)] //defaultta max olarak çalışır
        public string CatDescp { get; set; }

            
        //lazy loading LINQ -> virtual
        //eager loading
        public virtual ICollection<Product> Products { get; set; } //bire çok ilişki 
    }
}
