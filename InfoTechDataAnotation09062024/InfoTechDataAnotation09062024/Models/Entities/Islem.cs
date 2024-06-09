using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTechDataAnotation09062024.Models.Entities
{
    public class Islem
    {
        [Key]
        public int IslemNo { get; set; }


        [ForeignKey("Ogrenci")]
        public int OgrNo { get; set; }
        public virtual Ogrenci Ogrenci{ get; set; }


        [ForeignKey("Kitap")]
        public int KitapNo { get; set; }
        public virtual Kitap Kitap { get; set; }


        public DateTime ATarih { get; set; }
        public DateTime VTarih { get; set; }

    }
}
