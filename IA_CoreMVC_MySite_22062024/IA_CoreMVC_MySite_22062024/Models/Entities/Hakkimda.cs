using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Hakkimda //blog
    {
        [Key] public int ID { get; set; }
        [MaxLength(100)] public string Baslik { get; set; }
        public string Yazi { get; set; }
        public DateTime YaziTarih { get; set; }
        [MaxLength(255)] public string? YaziFoto { get; set; }
    }
}
