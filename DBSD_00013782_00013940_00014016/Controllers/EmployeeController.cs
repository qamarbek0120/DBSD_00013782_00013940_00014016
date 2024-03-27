using DBSD_00013782_00013940_00014016.DAL;
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

        public IActionResult Index(
        {
            var list = _employeeRepository.GetAll();
            return View(list);
        }
    }
}
