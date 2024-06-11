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
            var selected = _db.Set<Student>().Where(w => w.StudentID == entity.StudentID).FirstOrDefault();

            if (selected == null)
            {
                //if(entity.Point < 0 || entity.Point > 100)
                //{
                    
                //}

                _db.Set<Student>().Add(entity);
            }
            else
            {
                selected.IsDeleted = false;
            }

            _db.SaveChanges();
        }

        public void Delete(Student entity)
        {
            var student = GetById(entity.StudentID);
            if (student != null)
            {
                student.IsDeleted = true;
                _db.Set<Student>().Update(student);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Set<Student>().Where(w => w.IsDeleted != true).ToList();
        }

        public Student GetById(int id)
        {
            return _db.Set<Student>().FirstOrDefault(w => w.StudentID == id);
        }

        public void Update(Student entity)
        {
            var student = GetById(entity.StudentID);
            if (student != null)
            {
                _db.Entry(student).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
        }
    }
}
