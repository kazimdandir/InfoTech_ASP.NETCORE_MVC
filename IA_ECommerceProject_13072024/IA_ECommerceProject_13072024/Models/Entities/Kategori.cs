using System.ComponentModel.DataAnnotations;

namespace IA_ECommerceProject_13072024.Models.Entities
{
    public class Kategori
    {
        [Key] public int KategoriID { get; set; }
        [MaxLength(50)] public string KategoriAdi { get; set; }
        public string KategoriAciklamasi { get; set; }

        //Urun
        public virtual List<Urun> Urun { get; set; }
    }
}
