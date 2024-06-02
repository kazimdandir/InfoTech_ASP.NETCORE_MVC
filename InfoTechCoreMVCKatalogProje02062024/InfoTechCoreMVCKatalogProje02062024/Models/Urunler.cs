using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCKatalogProje02062024.Models
{
    public partial class Urunler
    {
        public int UrunId { get; set; }

        [Display(Name = "Ürün Adı")]
        public string UrunAdi { get; set; } = null!;

        [Display(Name = "Ürün Açıklaması")]
        public string? UrunAciklama { get; set; }

        public decimal UrunFiyat { get; set; }
        public int UrunStokAdet { get; set; }
        public int KategoriRefId { get; set; }

        public virtual Kategori KategoriRef { get; set; } = null!;
    }
}
