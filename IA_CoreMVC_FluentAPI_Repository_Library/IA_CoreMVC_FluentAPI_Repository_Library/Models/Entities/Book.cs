namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public long? IsbnNo { get; set; }
        public string? BookName { get; set; }
        public int? WriterID { get; set; }
        public int? TypeID { get; set; }
        public int? PageCount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BookType Type { get; set; }
        public virtual Writer Writer { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
