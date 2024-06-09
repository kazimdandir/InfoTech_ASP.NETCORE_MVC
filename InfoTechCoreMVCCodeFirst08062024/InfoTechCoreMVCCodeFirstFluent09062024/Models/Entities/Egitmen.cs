using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCCodeFirstFluent09062024.Models.Entities
{
    public class Egitmen
    {
        public int EgitmenID { get; set; }
        public string EgitmenAdi { get; set; }
        public string EgitmenSoyadi { get; set; }

        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
    }
}
