using System.ComponentModel.DataAnnotations;

namespace InfoTechMVCCoreTemplate26052024.Models
{
    public class Ogrenci
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "İsminizi girmelisiniz.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyisminizi girmelisiniz.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Sizinle iletişime geçebilmemiz adına lütfen telefon numaranızı yazınız.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Sizinle iletişime geçebilmemiz adına lütfen e-posta adresinizi yazınız.")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Katılım durumunuzu belirtmeniz gerekmektedir.")]
        public bool? Katilim { get; set; }
    }
}
