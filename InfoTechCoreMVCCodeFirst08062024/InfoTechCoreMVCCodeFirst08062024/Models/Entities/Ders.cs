using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Entities
{
    public class Ders
    {
        [Key] 
        public int DersID { get; set; }

        [MaxLength(50)]
        public string DersAdi { get; set; }

        public short DersSaati { get; set; }

        public virtual ICollection<Egitmen> Egitmen { get; set; }
    }
}
