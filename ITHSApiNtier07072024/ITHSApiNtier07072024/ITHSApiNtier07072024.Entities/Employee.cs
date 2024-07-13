using System.ComponentModel.DataAnnotations;

namespace ITHSApiNtier07072024.Entities
{
    public class Employee
    {
        public int ID { get; set; }

        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }

        [StringLength(75)]
        public string Department { get; set; }
    }
}
