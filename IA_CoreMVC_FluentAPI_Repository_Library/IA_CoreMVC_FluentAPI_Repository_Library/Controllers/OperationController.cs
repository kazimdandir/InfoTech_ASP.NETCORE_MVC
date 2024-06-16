using IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Concrete;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;
using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Controllers
{
    public class OperationController : Controller
    {
        private readonly IRepository<Operation> _useRepo;
        LibraryContext db = new LibraryContext();

        public OperationController()
        {
            _useRepo = new RepositoryOperation(DBSingleton.GetInstance());
        }

        public IActionResult Index()
        {


            try
            {
                var model = _useRepo.GetAll();
                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void ViewBags()
        {
            ViewBag.Books = new SelectList(db.Set<Book>().Where(b => b.IsDeleted != true).ToList(), "BookID", "BookName");

            var students = db.Set<Student>().Where(s => s.IsDeleted != true).ToList();
            ViewBag.Students = students.Select(s => new SelectListItem
            {
                Value = s.StudentID.ToString(),
                Text = $"{s.StudentName} {s.StudentSurname}"
            }).ToList();
        }

        public IActionResult Create()
        {
            ViewBags();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Operation model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Add(model);
                return RedirectToAction("Index");
            }

            ViewBags();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Operation model = _useRepo.GetById(id);

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

            Operation model = _useRepo.GetById(id);

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

            Operation model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            ViewBags();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Operation model)
        
        {
            if (ModelState.IsValid)
            {
                _useRepo.Update(model);
                return RedirectToAction("Index");
            }

            ViewBags();

            return View(model);
        }
    }
}
