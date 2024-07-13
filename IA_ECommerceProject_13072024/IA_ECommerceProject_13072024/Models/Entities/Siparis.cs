using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IA_ECommerceProject_13072024.Models.Entities
{
    public class Siparis
    {
        [Key] public int SiparisID { get; set; }

        //Kullanici
        [ForeignKey("Kullanici")] public int RefKullaniciID { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        [MaxLength(50)] public string? Ad { get; set; }
        [MaxLength(50)] public string? Soyad { get; set; }
        public string? Adres { get; set; }
        [MaxLength(11)] public string? Telefon { get; set; }
        [MaxLength(11)] public string TCKimlikNo { get; set; }
        public DateTime Tarih { get; set; }

        public virtual List<SiparisKalem> SiparisKalem { get; set; }
    }
}
