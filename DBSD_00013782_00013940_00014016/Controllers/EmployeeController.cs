using DBSD_00013782_00013940_00014016.DAL;
using DBSD_00013782_00013940_00014016.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBSD_00013782_00013940_00014016.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var list = _employeeRepository.GetAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            empRepo.Insert(emp);
            return RedirectToAction("Index");
        }


    }
}
