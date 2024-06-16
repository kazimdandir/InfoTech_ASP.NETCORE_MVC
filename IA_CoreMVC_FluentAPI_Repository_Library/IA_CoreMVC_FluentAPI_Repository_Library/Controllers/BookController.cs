using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Book> _useRepo;
        LibraryContext db = new LibraryContext();

        public BookController()
        {
            _useRepo = new RepositoryBook(DBSingleton.GetInstance());
        }

        public IActionResult Index()
        {
            var model = _useRepo.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            var writers = db.Set<Writer>().Where(w => w.IsDeleted != true).ToList();
            ViewBag.Writers = writers.Select(w => new SelectListItem
            {
                Value = w.WriterID.ToString(),
                Text = $"{w.WriterName} {w.WriterSurname}"
            }).ToList();

            ViewBag.BookTypes = new SelectList(db.Set<BookType>().Where(bt => bt.IsDeleted != true).ToList(), "TypeID", "TypeName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Add(model);
                return RedirectToAction("Index");
            }

            // ModelState hata kontrolü
            var writerIdErrors = ModelState["WriterID"].Errors;
            foreach (var error in writerIdErrors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            // ViewBag tekrar doldurulması
            var writers = db.Set<Writer>().Where(w => w.IsDeleted != true).ToList();
            ViewBag.Writers = writers.Select(w => new SelectListItem
            {
                Value = w.WriterID.ToString(),
                Text = $"{w.WriterName} {w.WriterSurname}"
            }).ToList();

            ViewBag.BookTypes = new SelectList(db.Set<BookType>().Where(bt => bt.IsDeleted != true).ToList(), "TypeID", "TypeName");

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Book model = _useRepo.GetById(id);

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

            Book model = _useRepo.GetById(id);

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

            Book model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            var writers = db.Set<Writer>().Where(w => w.IsDeleted != true).ToList();
            ViewBag.Writers = writers.Select(w => new SelectListItem
            {
                Value = w.WriterID.ToString(),
                Text = $"{w.WriterName} {w.WriterSurname}"
            }).ToList();

            ViewBag.BookTypes = new SelectList(db.Set<BookType>().Where(bt => bt.IsDeleted != true).ToList(), "TypeID", "TypeName");

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Update(model);
                return RedirectToAction("Index");
            }

            var writers = db.Set<Writer>().Where(w => w.IsDeleted != true).ToList();
            ViewBag.Writers = writers.Select(w => new SelectListItem
            {
                Value = w.WriterID.ToString(),
                Text = $"{w.WriterName} {w.WriterSurname}"
            }).ToList();

            ViewBag.BookTypes = new SelectList(db.Set<BookType>().Where(bt => bt.IsDeleted != true).ToList(), "TypeID", "TypeName");

            return View(model);
        }
    }
}
