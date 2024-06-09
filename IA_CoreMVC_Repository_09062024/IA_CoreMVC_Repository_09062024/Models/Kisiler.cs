using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_Repository_09062024.Models
{
    public class Kisiler
    {
        [Key]
        public int KisiID { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
    }
}
