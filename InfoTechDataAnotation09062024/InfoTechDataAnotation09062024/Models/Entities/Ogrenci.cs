using System.ComponentModel.DataAnnotations;

namespace InfoTechDataAnotation09062024.Models.Entities
{
    public class Ogrenci
    {
        [Key]
        public int OgrNo { get; set; }


        [MaxLength(50)]
        public string OgrAd { get; set; }


        [MaxLength(50)]
        public string OgrSoyad { get; set; }


        [MaxLength(5)]
        public string Cinsiyet { get; set; }


        public DateTime DTarih { get; set; }


        [MaxLength(50)]
        public string Sinif { get; set; }


        public byte Puan { get; set; }


        public virtual ICollection<Islem> Islems { get; set; }
    }
}
