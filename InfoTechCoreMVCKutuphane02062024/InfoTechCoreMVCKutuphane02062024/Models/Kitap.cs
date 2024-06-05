using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKutuphane02062024.Models
{
    public partial class Kitap
    {
        public Kitap()
        {
            Islems = new HashSet<Islem>();
        }

        [Display(Name = "Kitap")]
        public int Kitapno { get; set; }

        [Display(Name = "ISBN")]
        public long? Isbnno { get; set; }

        [Display(Name = "Kitap Adı")]
        public string? Kitapadi { get; set; }

        [Display(Name = "Yazar")]
        public int? Yazarno { get; set; }

        [Display(Name = "Tür")]
        public int? Turno { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int? Sayfasayisi { get; set; }

        [Display(Name = "Silindi Mi")]
        public bool? Silindimi { get; set; }


        [Display(Name = "Tür")]
        public virtual Tur? TurnoNavigation { get; set; }

        [Display(Name = "Yazar")]
        public virtual Yazar? YazarnoNavigation { get; set; }
        public virtual ICollection<Islem> Islems { get; set; }
    }
}
