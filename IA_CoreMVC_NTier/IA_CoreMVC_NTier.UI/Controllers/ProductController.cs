using IA_CoreMVC_NTier.BL.Abstract;
using IA_CoreMVC_NTier.BL.Concrete;
using IA_CoreMVC_NTier.DAL.Concrete;
using IA_CoreMVC_NTier.DAL.Context;
using IA_CoreMVC_NTier.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_NTier.UI.Controllers
{
    public class ProductController : Controller
    {
        private IGeneralService<Product> _proService;

        ProjeContext db = new ProjeContext();

        public ProductController()
        {
            _proService = new ProductManager();
        }

        public IActionResult Index()
        {
            //product name, price, ... , category name
            return View(_proService.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Kategoriler = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) 
        {
            ViewBag.Kategoriler = db.Categories.ToList();

            _proService.Create(product);
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            ViewBag.Kategoriler = db.Categories.ToList();

            return View(_proService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ViewBag.Kategoriler = db.Categories.ToList();

            _proService.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _proService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ViewBag.Kategoriler = db.Categories.ToList();

            var product = _proService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            // Eager loading ile kategori bilgisini yükleyin
            product.Category = db.Categories.FirstOrDefault(c => c.CategoryID == product.CategoryId);

            return View(product);
        }
    }
}
