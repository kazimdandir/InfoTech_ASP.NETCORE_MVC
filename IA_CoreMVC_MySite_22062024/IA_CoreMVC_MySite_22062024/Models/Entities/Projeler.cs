using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Projeler
    {
        [Key] public int ProjeID { get; set; }

        [MaxLength(100)]
        [Display(Name = "Proje Adı")]
        [Required(ErrorMessage = "Proje adı girmelisiniz...")]
        public string ProjeAdi { get; set; }

        
        [Display(Name = "Proje Açıklaması")] 
        public string? ProjeAciklamasi { get; set; }

        [Display(Name = "Proje Tarihi")] public DateTime ProjeTarihi { get; set; }

        
        [Display(Name = "Proje Fotoğrafı")]
        [MaxLength(255)] 
        public string? ProjeFoto { get; set; }
    }
}
