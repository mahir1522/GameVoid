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
            if (TempData["VerificationMessage"] != null)
            {
                ViewBag.VerificationMessage = TempData["VerificationMessage"].ToString();
            }

            // Check if there's a message about account confirmation
            if (TempData["AccountConfirmed"] != null)
            {
                ViewBag.AccountConfirmed = TempData["AccountConfirmed"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            // Check if logged in as admin
            if (Admin.ValidateAdmin(username, password))
            {
                return RedirectToAction("Index", "Admin");
            }

            // Check if member exists in the database
            var existingMember = await _context.Members.FirstOrDefaultAsync(m => m.UserName == username);

            if (existingMember != null)
            {
                if (!existingMember.IsEmailVerified)
                {
                    ModelState.AddModelError("Email", "Your email is not verified. Please check your email for verification.");
                    ViewBag.ErrorMessage = "Your email is not verified. Please check your email for verification.";
                    return View();
                }

                if (password == existingMember.Password)
                {
                    return RedirectToAction("Index", "User", new {memberId = existingMember.MemberID});
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Password";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "User does not exist";
            }

            return View();
        }
    }
}
