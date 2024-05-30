using System.ComponentModel.DataAnnotations;

namespace InfoTechMVCCoreTemplate26052024.Models
{
    public class Ogrenci
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Eposta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Katılım durumu zorunludur.")]
        public bool? Katilim { get; set; }
    }

}
