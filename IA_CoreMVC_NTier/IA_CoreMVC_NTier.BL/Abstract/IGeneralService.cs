using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_CoreMVC_NTier.BL.Abstract
{
    public interface IGeneralService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T p);
        T Update(T p);
        void Delete(int id);
    }
}
