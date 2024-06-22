using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Kullanici
    {
        [Key] public int KullaniciID { get; set; }
        [MaxLength(50)] public string Adi { get; set; }
        [MaxLength(50)] public string Soyadi { get; set; }
        [MaxLength(10)] public string KullaniciAdi { get; set; }
        [MaxLength(10)] public string Parola { get; set; }
        [MaxLength(10)] public string Rolu { get; set; }
    }
}
