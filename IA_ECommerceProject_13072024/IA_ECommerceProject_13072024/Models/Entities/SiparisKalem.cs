using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IA_ECommerceProject_13072024.Models.Entities
{
    public class SiparisKalem
    {
        [Key] public int SiparisKalemID { get; set; }

        //Siparis
        [ForeignKey("Siparis")] public int RefSiparisID { get; set; }
        public virtual Siparis Siparis { get; set; }

        //Urun
        [ForeignKey("Urun")] public int RefUrunID { get; set; }
        public virtual Urun Urun { get; set; }

        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}
