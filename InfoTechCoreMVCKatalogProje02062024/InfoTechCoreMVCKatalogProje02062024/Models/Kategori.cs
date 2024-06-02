using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKatalogProje02062024.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            Urunlers = new HashSet<Urunler>();
        }

        public int KategoriId { get; set; }

        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; } = null!;

        [Display(Name = "Kategori Açıklaması")]
        public string? KategoriAciklama { get; set; }

        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
