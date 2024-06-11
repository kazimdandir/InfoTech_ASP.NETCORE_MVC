using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete
{
    public class RepositoryBookType : IRepository<BookType>
    {
        private readonly LibraryContext _db;

        public RepositoryBookType()
        {
            _db = DBSingleton.GetInstance();
        }

        public RepositoryBookType(LibraryContext _context)
        {
            _db = _context;
        }

        public void Add(BookType entity)
        {
            var selected = _db.Set<BookType>().Where(w => w.TypeID == entity.TypeID).FirstOrDefault();

            if (selected == null)
            {
                _db.Set<BookType>().Add(entity);
            }
            else
            {
                selected.IsDeleted = false;
            }

            _db.SaveChanges();
        }

        public void Delete(BookType entity)
        {
            var bookType = GetById(entity.TypeID);
            if (bookType != null)
            {
                bookType.IsDeleted = true;
                _db.Set<BookType>().Update(bookType);
                _db.SaveChanges();
            }
        }

        public IEnumerable<BookType> GetAll()
        {
            return _db.Set<BookType>().Where(w => w.IsDeleted != true).ToList();
        }

        public BookType GetById(int id)
        {
            return _db.Set<BookType>().FirstOrDefault(w => w.TypeID == id);
        }

        public void Update(BookType entity)
        {
            var bookType = GetById(entity.TypeID);
            if (bookType != null)
            {
                _db.Entry(bookType).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
        }
    }
}
