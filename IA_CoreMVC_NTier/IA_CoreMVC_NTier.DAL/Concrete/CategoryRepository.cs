using IA_CoreMVC_NTier.DAL.Abstract;
using IA_CoreMVC_NTier.DAL.Context;
using IA_CoreMVC_NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IA_CoreMVC_NTier.DAL.Concrete
{
    public class CategoryRepository : IGeneralRepository<Category>
    {
        ProjeContext db = new ProjeContext();

        public Category Create(Category p)
        {
            db.Categories.Add(p);
            db.SaveChanges();
            return p;
        }

        public void Delete(int id)
        {
            db.Categories.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();  
        }

        public Category GetById(int id)
        {
            return db.Categories.Find(id);
        }

        public List<Category> Search(Expression<Func<Category, bool>> predicate)
        {
            return db.Categories.Where(predicate).ToList();
        }

        public Category Single(Expression<Func<Category, bool>> predicate)
        {
            return db.Categories.Where(predicate).First();
        }

        public Category Update(Category p)
        {
            db.Entry(GetById(p.CategoryID)).CurrentValues.SetValues(p);
            db.SaveChanges();
            return p;
        }
    }
}
