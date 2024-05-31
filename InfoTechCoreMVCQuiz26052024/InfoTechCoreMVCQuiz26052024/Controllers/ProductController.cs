using InfoTechCoreMVCQuiz26052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechCoreMVCQuiz26052024.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection data)
        {
            TempData["ProductID"] = Convert.ToInt32(data["productId"]);
            TempData["ProductName"] = data["productName"].ToString();
            TempData["ProductPrice"] = Convert.ToInt32(data["productPrice"]);
            TempData["ProductStockQuantity"] = Convert.ToInt32(data["productStockQuantity"]);
            return RedirectToAction("ReceivedDataView", "Product");
        }

        public IActionResult ReceivedDataView()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = Repository.ProductList();
            ViewBag.TotalPrice = Repository.GetTotalPrice();
            ViewBag.TotalStockQuantity = Repository.GetTotalStockQuantity();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p)
        {
            if (ModelState.IsValid)
            {
                Repository.AddProduct(p);
                return RedirectToAction("ProductList"); // Başarılı eklemeden sonra listeye yönlendirme
            }
            return View(p); // Model hatalıysa formu tekrar göster
        }
    }
}
