using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete
{
    public class RepositoryBook : IRepository<Book>
    {
        private readonly LibraryContext _db;

        public RepositoryBook()
        {
            _db = DBSingleton.GetInstance();
        }

        public RepositoryBook(LibraryContext _context)
        {
            _db = _context;
        }

        public void Add(Book entity)
        {
            var selected = _db.Set<Book>().Where(b => b.BookID == entity.BookID).FirstOrDefault();

            if (selected == null)
            {
                _db.Set<Book>().Add(entity);
            }
            else
            {
                selected.IsDeleted = false;
            }

            _db.SaveChanges();
        }

        public void Delete(Book entity)
        {
            var book = GetById(entity.BookID);
            if (book != null)
            {
                book.IsDeleted = true;
                _db.Set<Book>().Update(book);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Set<Book>()
                .Include(b => b.Type)
                .Include(b => b.Writer)
                .Where(b => b.IsDeleted != true && b.Type.IsDeleted != true && b.Writer.IsDeleted != true)
                .OrderBy(b => b.BookID)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _db.Set<Book>()
                .Include(b => b.Type)
                .Include(b => b.Writer)
                .FirstOrDefault(b => b.BookID == id);
        }

        public void Update(Book entity)
        {
            var book = GetById(entity.BookID);
            if (book != null)
            {
                _db.Entry(book).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
        }
    }
}
