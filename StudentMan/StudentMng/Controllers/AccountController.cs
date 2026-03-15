using Microsoft.AspNetCore.Mvc;
using StudentMngSystem14_03_26.Models;
using StudentMngSystem14_03_26.ViewModels;
using System.Linq;

namespace StudentMngSystem14_03_26.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // Store user session
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserRole", user.Role);

                    // Redirect based on role
                    if (user.Role == "Teacher")
                    {
                        return RedirectToAction("Index", "TeacherDashboard");
                    }
                    else if (user.Role == "Student")
                    {
                        return RedirectToAction("Index", "StudentDashboard");
                    }
                }

                ViewBag.Message = "Invalid Email or Password";
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
