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
            var list = Repository.ProductList();

            var totalProductPrice = list.Sum(p => p.ProductPrice * p.ProductStockQuantity);
            var totalStockQuantity = list.Sum(p => p.ProductStockQuantity);

            ViewData["TotalProductPrice"] = totalProductPrice;
            ViewData["TotalStockQuantity"] = totalStockQuantity;

            return View(list);
        }

    }
}
