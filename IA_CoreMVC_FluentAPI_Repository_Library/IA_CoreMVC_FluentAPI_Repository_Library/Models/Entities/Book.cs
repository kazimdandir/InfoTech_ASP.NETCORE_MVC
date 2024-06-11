using System.ComponentModel.DataAnnotations;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Book
    {
        public int BookID { get; set; }

        [Display(Name = "Isbn No")]
        public long? IsbnNo { get; set; }

        [Display(Name = "Book Name")]
        public string? BookName { get; set; }

        [Display(Name = "Writer")]
        public int? WriterID { get; set; }

        [Display(Name = "Book Type")]
        public int? TypeID { get; set; }

        [Display(Name = "Page Count")]
        public int? PageCount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BookType Type { get; set; }
        public virtual Writer Writer { get; set; }

        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>(); 
    }
}
