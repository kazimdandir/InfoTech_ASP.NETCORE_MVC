using IA_CoreMVC_NTier.BL.Abstract;
using IA_CoreMVC_NTier.BL.Concrete;
using IA_CoreMVC_NTier.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_NTier.UI.Controllers
{
    public class CategoryController : Controller
    {
        private IGeneralService<Category> _catService;

        public CategoryController()
        {
            _catService = new CategoryManager();    
        }

        public IActionResult Index()
        {
            return View(_catService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _catService.Create(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_catService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _catService.Update(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _catService.Delete(id);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            Category model = _catService.GetById(id);
            return View(model);

        }
    }
}
