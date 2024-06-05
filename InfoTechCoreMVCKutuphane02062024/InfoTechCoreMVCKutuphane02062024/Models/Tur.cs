using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKutuphane02062024.Models
{
    public partial class Tur
    {
        public Tur()
        {
            Kitaps = new HashSet<Kitap>();
        }

        [Display(Name = "Tür")]
        public int Turno { get; set; }

        [Display(Name = "Tür Adı")]
        public string? Turadi { get; set; }

        [Display(Name = "Silindi Mi")]
        public bool? Silindimi { get; set; }

        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
