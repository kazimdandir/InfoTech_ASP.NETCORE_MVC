using Microsoft.AspNetCore.Mvc;
using InfoTech_ASP.NETCORE_EMPTY_MVC.Models;

namespace InfoTech_ASP.NETCORE_EMPTY_MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            
            return RedirectToAction("Index2");
            //return View(products);
        }
        public IActionResult Index2()
        {
            List<Product> products = new List<Product>();

            Product p1 = new Product
            {
                ID = 1,
                ProductName = "Laptop",
                Price = 30000,
                Description = "16GB RAM - 512GB SSD - i7 12700H",
                StockQuantity = 27
            };

            products.Add(p1);


            Product p2 = new Product
            {
                ID = 2,
                ProductName = "TV",
                Price = 25000,
                Description = "55 inch screen - Android TV - 4K",
                StockQuantity = 12
            };

            products.Add(p2);
            return View(products);
        }
    }
}
