using Microsoft.AspNetCore.Mvc;

namespace PROG3050_Team_Project.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
