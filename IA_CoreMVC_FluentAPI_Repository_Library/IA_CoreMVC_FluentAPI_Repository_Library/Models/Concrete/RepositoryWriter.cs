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
            _db.Set<Writer>().Add(entity);
        }

        public void Delete(Writer entity)
        {
            _db.Set<Writer>().Remove(GetById(entity.WriterID));
        }

        public IEnumerable<Writer> GetAll()
        {
            return _db.Set<Writer>().ToList();
        }

        public Writer GetById(int id)
        {
            return _db.Set<Writer>().Where(w => w.WriterID == id).First();
        }

        public void Update(Writer entity)
        {
            _db.Entry(GetById(entity.WriterID)).CurrentValues.SetValues(entity);
        }
    }
}
