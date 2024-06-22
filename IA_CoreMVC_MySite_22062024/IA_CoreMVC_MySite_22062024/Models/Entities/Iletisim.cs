using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Iletisim
    {
        [Key] public int IletisimID { get; set; }
        [MaxLength(50)] public string Ad { get; set; }
        [MaxLength(50)] public string Soyad { get; set; }
        [MaxLength(255)] public string EPosta { get; set; }
        public string Mesaj { get; set; }
    }
}
