using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKutuphane02062024.Models
{
    public partial class Yazar
    {
        public Yazar()
        {
            Kitaps = new HashSet<Kitap>();
        }

        [Display(Name = "Yazar")]
        public int Yazarno { get; set; }

        [Display(Name = "Yazar Adı")]
        public string? Yazarad { get; set; }

        [Display(Name = "Yazar Soyadı")]
        public string? Yazarsoyad { get; set; }

        [Display(Name = "Silindi Mi")]
        public bool? Silindimi { get; set; }

        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
