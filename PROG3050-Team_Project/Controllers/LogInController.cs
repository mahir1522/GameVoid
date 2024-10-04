using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using System.Text.RegularExpressions;

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
                return RedirectToAction("Index", "Admin");
            }

            // Check if member exists in database
            var existingMember = await _context.Members
          .FirstOrDefaultAsync(m => m.UserName == username);

            if (existingMember != null)
            {
                // ViewBag.ConsoleMessage = "User exists";
                if (password == existingMember.Password)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("Password", "Incorrect Password");
                }
            }
            else
            {
                ModelState.AddModelError("Username", "User does not exist");
            }

            return View();
        }
       
    }
}
