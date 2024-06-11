using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete
{
    public class RepositoryOperation : IRepository<Operation>
    {
        private readonly LibraryContext _db;

        public RepositoryOperation()
        {
            _db = DBSingleton.GetInstance();
        }

        public RepositoryOperation(LibraryContext _context)
        {
            _db = _context;
        }

        public void Add(Operation entity)
        {
            _db.Set<Operation>().Add(entity);
        }

        public void Delete(Operation entity)
        {
            _db.Set<Operation>().Remove(GetById(entity.OperationID));
        }

        public IEnumerable<Operation> GetAll()
        {
            return _db.Set<Operation>()
                .Include(o => o.Book)
                .Include(o => o.Student)
                .ToList();
        }

        public Operation GetById(int id)
        {
            return _db.Set<Operation>()
                .Include(o => o.Book)
                .Include(o => o.Student)
                .Where(o => o.OperationID == id)
                .First(); 
        }

        public void Update(Operation entity)
        {
            _db.Entry(GetById(entity.OperationID)).CurrentValues.SetValues(entity);
        }
    }
}
