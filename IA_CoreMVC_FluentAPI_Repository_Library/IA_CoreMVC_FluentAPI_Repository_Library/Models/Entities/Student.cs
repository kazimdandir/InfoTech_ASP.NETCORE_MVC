using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Student
    {
        public int StudentID { get; set; }

        [Display(Name = "Name")]
        public string? StudentName { get; set; }

        [Display(Name = "Surname")]
        public string? StudentSurname { get; set; }

        public string? Gender { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Class")]
        public string? SchoolRoom { get; set; }

        public short? Point { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
    }
}
