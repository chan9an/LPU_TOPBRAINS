using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMngSystem14_03_26.Models;

namespace StudentMngSystem14_03_26.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses.Include(c => c.Department);
            return View(await courses.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}