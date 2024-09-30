using Microsoft.AspNetCore.Mvc;
using PROG3050_Team_Project.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PROG3050_Team_Project.Controllers
{
    public class SignUpController : Controller
    {
        private GameVoidContext _context; 

        public SignUpController(GameVoidContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Member member)
        {
            // Validate the model
            if (ModelState.IsValid)
            {
                // Validate the password strength
                var passwordCriteria = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
                if (!passwordCriteria.IsMatch(member.Password))
                {
                    ModelState.AddModelError("Password", "Password must be at least 8 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character.");
                    return View(member); // Return to the signup view with validation errors
                }

                _context.Members.Add(member);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
