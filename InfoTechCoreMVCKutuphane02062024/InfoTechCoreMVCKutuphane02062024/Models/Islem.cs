using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKutuphane02062024.Models
{
    public partial class Islem
    {
        [Display(Name = "İşlem")]
        public int Islemno { get; set; }

        [Display(Name = "Öğrenci")]
        public int? Ogrno { get; set; }

        [Display(Name = "Kitap")]
        public int? Kitapno { get; set; }

        [Display(Name = "Alış Tarihi")]
        public DateTime? Atarih { get; set; }

        [Display(Name = "Veriş Tarihi")]
        public DateTime? Vtarih { get; set; }

        [Display(Name = "Teslim Edildi Mi")]
        public bool? Teslim { get; set; }

        [Display(Name = "Kitap")]
        public virtual Kitap? KitapnoNavigation { get; set; }

        [Display(Name = "Öğrenci")]
        public virtual Ogrenci? OgrnoNavigation { get; set; }
    }
}
