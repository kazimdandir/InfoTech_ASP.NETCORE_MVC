using System.ComponentModel.DataAnnotations;

namespace InfoTechMVCCoreTemplate26052024.Models
{
    public class Ogrenci
    {
        [Required(ErrorMessage ="İsim Girmelisin")]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public bool? Katilim { get; set; }
    }
}
