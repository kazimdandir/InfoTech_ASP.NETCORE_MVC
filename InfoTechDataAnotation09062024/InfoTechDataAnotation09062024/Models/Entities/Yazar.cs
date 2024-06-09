using System.ComponentModel.DataAnnotations;

namespace InfoTechDataAnotation09062024.Models.Entities
{
    public class Yazar
    {
        [Key]
        public int YazarNo { get; set; }


        [MaxLength(50)]
        public string YazarAdi { get; set; }


        [MaxLength(50)]
        public string YazarSoyadi { get; set; }


        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
