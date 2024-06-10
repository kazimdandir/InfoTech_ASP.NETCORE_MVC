using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete
{
    public class RepositoryStudent : IRepository<Student>
    {
        private readonly LibraryContext _db;

        public RepositoryStudent()
        {
            _db = DBSingleton.GetInstance();
        }

        public RepositoryStudent(LibraryContext _context)
        {
            _db = _context;
        }

        public void Add(Student entity)
        {
            _db.Set<Student>().Add(entity);
        }

        public void Delete(Student entity)
        {
            _db.Set<Student>().Remove(GetById(entity.StudentID));
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Set<Student>().ToList();
        }

        public Student GetById(int id)
        {
            return _db.Set<Student>().Where(s => s.StudentID == id).First(); 
        }

        public void Update(Student entity)
        {
            _db.Entry(GetById(entity.StudentID)).CurrentValues.SetValues(entity);
        }
    }
}
