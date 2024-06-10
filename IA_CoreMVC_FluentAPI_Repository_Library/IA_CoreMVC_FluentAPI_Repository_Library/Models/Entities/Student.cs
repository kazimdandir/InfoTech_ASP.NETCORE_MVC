namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? SchoolRoom { get; set; }
        public short? Point { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
