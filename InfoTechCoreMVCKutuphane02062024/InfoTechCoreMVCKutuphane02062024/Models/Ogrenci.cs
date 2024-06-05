using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKutuphane02062024.Models
{
    public partial class Ogrenci
    {
        public Ogrenci()
        {
            Islems = new HashSet<Islem>();
        }

        [Display(Name = "Öğrenci")]
        public int Ogrno { get; set; }

        [Display(Name = "Öğrenci Adı")]
        public string? Ograd { get; set; }

        [Display(Name = "Öğrenci Soyadı")]
        public string? Ogrsoyad { get; set; }

        [Display(Name = "Cinsiyet")]
        public string? Cinsiyet { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? Dtarih { get; set; }

        [Display(Name = "Sınıf")]
        public string? Sinif { get; set; }

        [Display(Name = "Puan")]
        public int? Puan { get; set; }

        [Display(Name = "Silindi Mi")]
        public bool? Silindimi { get; set; }

        public virtual ICollection<Islem> Islems { get; set; }
    }
}
