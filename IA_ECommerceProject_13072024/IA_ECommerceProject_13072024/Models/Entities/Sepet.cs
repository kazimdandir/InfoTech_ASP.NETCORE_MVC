using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IA_ECommerceProject_13072024.Models.Entities
{
    public class Sepet
    {
        [Key] public int SepetID { get; set; }

        //Kullanici
        [ForeignKey("Kullanici")] public int RefKullaniciID { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        //Urun
        [ForeignKey("Urun")] public int RefUrunID { get; set; }
        public virtual Urun Urun { get; set; }

        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}
