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
    public class CategoryManager : IGeneralService<Category>
    {
        private IGeneralRepository<Category> _catRepo;

        public CategoryManager()
        {
            _catRepo = new CategoryRepository();
        }

        public Category Create(Category p)
        {
            return _catRepo.Create(p);  
        }

        public void Delete(int id)
        {
            _catRepo.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _catRepo.GetAll();
        }

        public Category GetById(int id)
        {
            if (id > 0)
            {
                return _catRepo.GetById(id);
            }

            throw new Exception("id 0 dan büyük değil");
        }

        public Category Update(Category p)
        {
            return _catRepo.Update(p);
        }
    }
}
