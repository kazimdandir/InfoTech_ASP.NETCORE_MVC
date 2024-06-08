using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Entities
{
    public class StudentAddress
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentAddressID { get; set; }

        public string Address { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Lütfen bu alanı doldurun")]
        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
}
