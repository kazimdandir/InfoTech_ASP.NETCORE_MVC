using IA_CoreMVC_NTier.BL.Abstract;
using IA_CoreMVC_NTier.DAL.Abstract;
using IA_CoreMVC_NTier.DAL.Concrete;
using IA_CoreMVC_NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_CoreMVC_NTier.BL.Concrete
{
    public class ProductManager : IGeneralService<Product>
    {
        private IGeneralRepository<Product> _proRepo;

        public ProductManager()
        {
            _proRepo = new ProductRepository();
        }

        public Product Create(Product p)
        {
            return _proRepo.Create(p);
        }

        public void Delete(int id)
        {
            _proRepo.Delete(id);
        }

        public List<Product> GetAll()
        {
            return _proRepo.GetAll();
        }

        public Product GetById(int id)
        {
            if (id > 0)
            {
                return _proRepo.GetById(id);
            }

            throw new Exception("id 0 dan büyük değil");
        }

        public Product Update(Product p)
        {
            return _proRepo.Update(p);
        }
    }
}
