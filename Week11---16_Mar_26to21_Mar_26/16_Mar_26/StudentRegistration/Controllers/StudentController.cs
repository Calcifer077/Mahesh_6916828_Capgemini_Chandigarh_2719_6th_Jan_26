using Microsoft.AspNetCore.Mvc;
using StudentRegistrationApp.Models;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                // Simulate ID generation
                student.Id = new Random().Next(1000, 9999);

                // Store success message
                TempData["SuccessMessage"] = "Student registered successfully!";

                return RedirectToAction("Details", new { id = student.Id });
            }

            return View(student);
        }

        public IActionResult Details(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }
    }
}
