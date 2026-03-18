using Microsoft.AspNetCore.Mvc;

namespace SessionBasedLogin.Controllers
{
    public class AccountController : Controller
    {
        // Show Login Page
        public IActionResult Login()
        {
            return View();
        }

        // Handle Login Form
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                // Store username in session
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        // Dashboard Page
        public IActionResult Dashboard()
        {
            var username = HttpContext.Session.GetString("Username");

            if (username == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Username = username;
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}