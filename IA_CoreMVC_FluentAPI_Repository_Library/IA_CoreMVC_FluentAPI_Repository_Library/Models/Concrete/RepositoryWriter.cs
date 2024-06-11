using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete
{
    public class RepositoryWriter : IRepository<Writer>
    {
        private readonly LibraryContext _db;

        public RepositoryWriter()
        {
            _db = DBSingleton.GetInstance();
        }

        public RepositoryWriter(LibraryContext _context)
        {
            _db = _context;
        }

        public void Add(Writer entity)
        {
            var selected = _db.Set<Writer>().Where(w => w.WriterID == entity.WriterID).FirstOrDefault();

            if (selected == null)
            {
                _db.Set<Writer>().Add(entity);
            }
            else
            {
                selected.IsDeleted = false;
            }

            _db.SaveChanges();
        }

        public void Delete(Writer entity)
        {
            var writer = GetById(entity.WriterID);
            if (writer != null)
            {
                writer.IsDeleted = true;
                _db.Set<Writer>().Update(writer);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Writer> GetAll()
        {
            return _db.Set<Writer>().Where(w => w.IsDeleted != true).ToList();
        }

        public Writer GetById(int id)
        {
            return _db.Set<Writer>().FirstOrDefault(w => w.WriterID == id);
        }

        public void Update(Writer entity)
        {
            var writer = GetById(entity.WriterID);
            if (writer != null)
            {
                _db.Entry(writer).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
        }
    }
}
