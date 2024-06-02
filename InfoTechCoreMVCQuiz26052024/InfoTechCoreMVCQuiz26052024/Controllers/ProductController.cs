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
                return RedirectToAction("ProductList"); // Redirect to list page after successful addition
            }
            return View(p); // If the model is incorrect, show the form again
        }

        public IActionResult UserProduct()
        {
            var viewModel = new UserProductViewModel
            {
                Users = Repository.UserList(),
                Products = Repository.ProductList()
            }; 

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Repository.DeleteProduct(id);
                return Json(new { success = true, message = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = Repository.products.FirstOrDefault(x => x.ProductID == id);
            return View(item);
        }

        [HttpPost]
        public JsonResult Update(int id, Product p)
        {
            //entry methodu dene
            try
            {
                Repository.UpdateProduct(id, p);
                return Json(new { success = true, message = "Updated successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
