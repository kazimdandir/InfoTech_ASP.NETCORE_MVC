using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Entities
{
    public class Egitmen
    {
        [Key]
        public int EgitmenID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Adı zorunlu olmalı")]
        public string Adi { get; set; }

        [MaxLength(50)]
        [Required]
        public string Soyadi { get; set; }

        public virtual ICollection<Ders> Ders { get; set; }
    }
}
