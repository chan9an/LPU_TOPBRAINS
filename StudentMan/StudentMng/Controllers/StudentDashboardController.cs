using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMngSystem14_03_26.Models;

namespace StudentMngSystem14_03_26.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile(int id)
        {
            var student = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Course)
                .FirstOrDefault(s => s.StudentId == id);

            return View(student);
        }

        public IActionResult EditProfile(int id)
        {
            var student = _context.Students.Find(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult EditProfile(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                _context.SaveChanges();

                return RedirectToAction("Profile", new { id = student.StudentId });
            }

            return View(student);
        }
    }
}