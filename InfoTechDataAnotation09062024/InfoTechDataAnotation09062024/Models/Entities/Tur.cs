using System.ComponentModel.DataAnnotations;

namespace InfoTechDataAnotation09062024.Models.Entities
{
    public class Tur
    {
        [Key]
        public int TurNo {  get; set; }


        [MaxLength(50)]
        public string TurAdi { get; set; }


        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
