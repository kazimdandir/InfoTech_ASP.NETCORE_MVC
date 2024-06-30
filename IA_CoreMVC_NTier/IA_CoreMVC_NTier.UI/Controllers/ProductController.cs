using IA_CoreMVC_NTier.BL.Abstract;
using IA_CoreMVC_NTier.BL.Concrete;
using IA_CoreMVC_NTier.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_NTier.UI.Controllers
{
    public class ProductController : Controller
    {
        private IGeneralService<Product> _proService;

        public ProductController()
        {
            //_proService = new ProductManager();
        }

        public IActionResult Index()
        {
            //product name, price, ... , category name
            return View();
        }
    }
}
