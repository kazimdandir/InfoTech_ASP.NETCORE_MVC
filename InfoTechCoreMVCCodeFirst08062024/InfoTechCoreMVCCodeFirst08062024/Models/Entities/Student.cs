using System.ComponentModel.DataAnnotations;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentNo { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        public virtual StudentAddress StudentAddress { get; set; } //birebir
    }
}
