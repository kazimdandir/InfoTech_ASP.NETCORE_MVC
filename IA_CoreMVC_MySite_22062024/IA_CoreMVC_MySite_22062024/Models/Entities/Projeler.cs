using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_MySite_22062024.Models.Entities
{
    public class Projeler
    {
        [Key] public int ProjeID { get; set; }
        [MaxLength(100)] public string ProjeAdi { get; set; }
        public string ProjeAciklamasi { get; set; }
        public DateTime ProjeTarihi { get; set; }
        [MaxLength(255)] public string? ProjeFoto { get; set; }
    }
}
