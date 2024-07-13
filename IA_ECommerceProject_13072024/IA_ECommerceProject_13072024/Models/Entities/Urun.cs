using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IA_ECommerceProject_13072024.Models.Entities
{
    public class Urun
    {
        [Key] public int UrunID { get; set; }
        [MaxLength(250)] public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public decimal UrunFiyati { get; set; }
        [MaxLength(255)] public string? UrunFoto { get; set; }

        //Kategori
        [ForeignKey("Kategori")] public int RefKategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }

        public virtual List<Sepet> Sepet { get; set; }
        public virtual List<SiparisKalem> SiparisKalem { get; set; }
    }
}
