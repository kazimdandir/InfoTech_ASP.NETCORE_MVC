using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IA_CoreMVC_NTier.DAL.Abstract
{
    public interface IGeneralRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T p);
        T Update(T p);
        void Delete(int id);

        List<T> Search(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
    }
}
