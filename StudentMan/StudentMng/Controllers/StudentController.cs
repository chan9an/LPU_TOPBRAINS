using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMngSystem14_03_26.Models;

namespace StudentMngSystem14_03_26.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Course);

            return View(await students.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName", student.CourseId);

            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);

            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName", student.CourseId);

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}