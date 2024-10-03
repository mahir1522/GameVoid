using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;

namespace PROG3050_Team_Project.Controllers
{
    public class LogInController : Controller
    {
        private readonly GameVoidContext _context;
        public LogInController(GameVoidContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            // Check if logged as admin
            if (Admin.ValidateAdmin(username, password))
            {
                ViewBag.ConsoleMessage = "Admin login successful";
                return RedirectToAction("Index", "Admin");
            }

            // Check if member exists in database
            var existingMember = await _context.Members
          .FirstOrDefaultAsync(m => m.UserName == username);

            if (existingMember != null)
            {
                ViewBag.ConsoleMessage = "User exists";
                if (password == existingMember.Password)
                {
                    ViewBag.ConsoleMessage = "Login successful";
                }
                else
                {
                    ViewBag.ConsoleMessage = "Incorrect Password";
                }
            }
            else
            {
                ViewBag.ConsoleMessage = "User does not exist";
            }

            return View();
        }
       
    }
}
