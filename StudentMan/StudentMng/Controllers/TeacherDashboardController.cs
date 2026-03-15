using Microsoft.AspNetCore.Mvc;

namespace StudentMngSystem14_03_26.Controllers
{
    public class TeacherDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
