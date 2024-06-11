using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Writer
    {
        public int WriterID { get; set; }

        [Display(Name = "Writer Name")]
        public string WriterName { get; set; }

        [Display(Name = "Writer Surname")]
        public string WriterSurname { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
