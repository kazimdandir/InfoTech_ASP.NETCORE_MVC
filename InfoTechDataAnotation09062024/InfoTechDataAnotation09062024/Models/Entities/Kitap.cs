using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTechDataAnotation09062024.Models.Entities
{
    public class Kitap
    {
        [Key]
        public int KitapNo { get; set; }


        [StringLength(13, MinimumLength = 13, ErrorMessage = "13 karakterli olmalı")]
        public string IsbnNo { get; set; }


        [MaxLength(100)]
        public string KitapAdi { get; set; }
        public int SayfaSayisi { get; set; }
        public byte Puan { get; set; }


        [ForeignKey("Tur")]
        public int TurNo { get; set; }
        public virtual Tur Tur { get; set; }


        [ForeignKey("Yazar")]
        public int YazarNo { get; set; }
        public virtual Yazar Yazar { get; set; }


        public virtual ICollection<Islem> Islems { get; set; }
    }
}
