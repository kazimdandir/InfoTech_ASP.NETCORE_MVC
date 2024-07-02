using IA_CoreMVC_NTier.DAL.Abstract;
using IA_CoreMVC_NTier.DAL.Context;
using IA_CoreMVC_NTier.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IA_CoreMVC_NTier.DAL.Concrete
{
    public class ProductRepository : IGeneralRepository<Product>
    {
        ProjeContext db = new ProjeContext();

        public Product Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return p;
        }

        public void Delete(int id)
        {
            db.Products.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            var list = db.Products
                .Include(p => p.Category)
                .ToList();
            return list;
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public Product Single(Expression<Func<Product, bool>> predicate)
        {
            return db.Products.Where(predicate).First();
        }

        public Product Update(Product p)
        {
            db.Entry(GetById(p.ProductId)).CurrentValues.SetValues(p);
            db.SaveChanges();
            return p;
        }
    }
}
