using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Controllers
{
    public class WriterController : Controller
    {
        private IRepository<Writer> _useRepo;
        LibraryContext db = new LibraryContext();

        public WriterController()
        {
            _useRepo = new RepositoryWriter(DBSingleton.GetInstance());
        }

        public IActionResult Index()
        {
            var model = _useRepo.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Writer model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Add(model);
                return RedirectToAction("Index");
            }

            //// ModelState hata kontrolü
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //foreach (var error in errors)
            //{
            //    Console.WriteLine(error.ErrorMessage);
            //}

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Writer model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            _useRepo.Delete(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Writer model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Writer model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Writer model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Update(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
