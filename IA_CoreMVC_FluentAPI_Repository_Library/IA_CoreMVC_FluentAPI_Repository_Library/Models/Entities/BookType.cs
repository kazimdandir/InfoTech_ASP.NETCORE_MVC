namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class BookType
    {
        public int TypeID { get; set; }
        public string? TypeName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
