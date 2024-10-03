using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROG3050_Team_Project.Controllers
{
    public class SignUpController : Controller
    {
        private readonly GameVoidContext _context;

        public SignUpController(GameVoidContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Member());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Member member)
        {
            // Check if Password and ConfirmPassword match
            if (member.Password != member.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                ViewBag.ConsoleMessage = "Passwords do not match.";
                return View(member);
            }

            // Check for existing user
            var existingMember = await _context.Members
                .FirstOrDefaultAsync(m => m.UserName == member.UserName);

            if (existingMember != null)
            {
                ModelState.AddModelError("UserName", "Username is already taken.");
                ViewBag.ConsoleMessage = "Username already taken.";
                return View(member);
            }

            // Validate the password strength
            var passwordCriteria = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
            if (!passwordCriteria.IsMatch(member.Password))
            {
                ModelState.AddModelError("Password", "Password is not strong enough.");
                ViewBag.ConsoleMessage = "Password not strong enough.";
                return View(member);
            }

            // Add new member if the model state is valid
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                ViewBag.ConsoleMessage = "Added member successfully.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ConsoleMessage = "Member not valid.";
            }

            return View(member);
        }
    }
}
