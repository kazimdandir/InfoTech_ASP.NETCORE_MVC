using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Hakkimda //blog
    {
        [Key] public int ID { get; set; }

        [MaxLength(100)] 
        [Display(Name = "Blog Başlığı")] 
        [Required(ErrorMessage = "Blog başlığı boş bırakılamaz.")] 
        public string Baslik { get; set; }

        [Display(Name = "Yazı")]
        [Required(ErrorMessage = "Yazı boş bırakılamaz.")]
        public string Yazi { get; set; }

        [Display(Name = "Yazı Tarihi")]
        [Required(ErrorMessage = "Tarih seçimi yapmalısınız.")]
        public DateTime YaziTarih { get; set; }

        [Display(Name = "Yazı Fotoğrafı")] 
        [MaxLength(255)] 
        public string? YaziFoto { get; set; }
    }
}
