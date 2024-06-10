namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string? WriterName { get; set; }
        public string? WriterSurname { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
