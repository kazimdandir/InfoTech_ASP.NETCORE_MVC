using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Iletisim
    {
        [Key] public int IletisimID { get; set; }

        [Required(ErrorMessage = "Adınızı giriniz.")]
        [MaxLength(50)] 
        public string Ad { get; set; }
        
        [MaxLength(50)]
        [Required(ErrorMessage = "Soyadınızı giriniz.")]
        public string Soyad { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "E-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")] 
        public string EPosta { get; set; }

        [Required(ErrorMessage = "Mesajınızı giriniz.")]
        public string Mesaj { get; set; }

        [Required]
        public DateTime Tarih { get; set; } = DateTime.Now;
    }
}
