using Microsoft.AspNetCore.Mvc;
using EmployeePortal.Filters;

namespace EmployeePortal.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeList()
        {
            return View();
        }

        public IActionResult Reports()
        {
            throw new Exception("Error generating report");
        }
    }
}