using InfoTechMVCCoreVM01062024.Models;
using InfoTechMVCCoreVM01062024.Models.Enums;
using InfoTechMVCCoreVM01062024.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechMVCCoreVM01062024.Controllers
{
    public class PersonelController : Controller
    {
        static List<Personel> personeller = new List<Personel>()
        {

           new Personel{ID=1,Name="Ali Mali",BirthDate=new DateTime(2000,01,01),WorkingType=WorkingType.FullTime},
           new Personel{ID=2,Name="Veli Meli",BirthDate=new DateTime(1995,01,01),WorkingType=WorkingType.Freelance},
           new Personel{ID=3,Name="Behçet Necati",BirthDate=new DateTime(2002,01,01),WorkingType=WorkingType.FullTime},
           new Personel{ID=4,Name="Yılmaz Yılmaz",BirthDate=new DateTime(1995,01,01),WorkingType=WorkingType.PartTime}
        };

        List<Department> departmanlar = new List<Department>()
        {
           new Department{ID=1,DepartmentName="Yazılım"},
           new Department{ID=2,DepartmentName="Muhasebe"},
           new Department{ID=3,DepartmentName="Donanım"},
           new Department{ID=4,DepartmentName="IT"},
           new Department{ID=5,DepartmentName="IK"}
        };

        public IActionResult Index()
        {
            return View(personeller);
        }

        public IActionResult Create()
        {
            CreateVM vm = new CreateVM();
            vm.Personel = new Personel();
            vm.Departments = departmanlar;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Personel personel)
        {
            personeller.Add(personel);
            return RedirectToAction("Index");
        }
    }
}
