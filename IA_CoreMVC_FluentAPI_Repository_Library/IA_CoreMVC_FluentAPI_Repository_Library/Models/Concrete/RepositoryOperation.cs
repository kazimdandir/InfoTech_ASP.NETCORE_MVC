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
            var selected = _db.Set<Operation>().Where(o => o.OperationID == entity.OperationID).FirstOrDefault();

            if (selected == null)
            {
                _db.Set<Operation>().Add(entity);
            }
            else
            {
                selected.IsDelivered = false;
            }

            _db.SaveChanges();

        }

        public void Delete(Operation entity)
        {
            var operation = GetById(entity.OperationID);
            if (operation != null)
            {
                operation.IsDelivered = true;
                _db.Set<Operation>().Update(operation);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Operation> GetAll()
        {
            return _db.Set<Operation>()
                .Include(o => o.Book)
                .Include(o => o.Student)
                .Where(o => o.IsDelivered != true || o.DeliveryDate != null && o.Book.IsDeleted != true && o.Student.IsDeleted != true)
                .OrderBy(o => o.OperationID)
                .ToList();
        }

        public Operation GetById(int id)
        {
            return _db.Set<Operation>()
                .Include(o => o.Book)
                .Include(o => o.Student)
                .Where(o => o.OperationID == id)
                .FirstOrDefault(); 
        }

        public void Update(Operation entity)
        {
            _db.Entry(GetById(entity.OperationID)).CurrentValues.SetValues(entity);
        }
    }
}
