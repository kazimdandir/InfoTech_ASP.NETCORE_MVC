using IA_CoreMVC_Repository_09062024.Models;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_Repository_09062024.Controllers
{
    public class KisiController : Controller
    {
        private IRepository<Kisiler> _useRepo;

        public KisiController()
        {
            _useRepo = new RepositoryKisiler(DBSingleton.GetInstance());
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
        public IActionResult Create(Kisiler model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Add(model);
                _useRepo.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Kisiler model)
        {
            if (ModelState.IsValid)
            {
                _useRepo.Update(model);
                _useRepo.Save();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Kisiler model = _useRepo.GetById(id);   

            _useRepo.Delete(model);
            _useRepo.Save();

            if (model == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = _useRepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
