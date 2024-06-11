using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class BookType
    {
        public int TypeID { get; set; }

        [Display(Name = "Book Type")]
        public string? TypeName { get; set; }

        public bool? IsDeleted { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
