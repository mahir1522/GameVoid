using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        public async Task<IActionResult> Index(Member member, string gRecaptchaRes)
        {
            if(!ModelState.IsValid)
            {
                foreach(var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    Console.Write($"Model Error: {error.ErrorMessage}");
                }
                return View(member);    
            }

            Console.WriteLine("Reached Index POST method");

            // Step 1: Validate reCAPTCHA first
            if (!await ValidateRecaptcha(gRecaptchaRes))
            {
                Console.WriteLine("reCAPTCHA validation failed");
                ModelState.AddModelError("CaptchaError", "Please verify that you're not a robot.");
                return View(member);
            }

            // Step 2: Check if Password and ConfirmPassword match
            if (member.Password != member.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                ViewBag.ConsoleMessage = "Passwords do not match.";
                return View(member);
            }

            // Step 3: Check for existing user
            var existingMember = await _context.Members
                .FirstOrDefaultAsync(m => m.UserName == member.UserName);

            if (existingMember != null)
            {
                ModelState.AddModelError("UserName", "Username is already taken.");
                ViewBag.ConsoleMessage = "Username already taken.";
                return View(member);
            }

            // Step 4: Validate the password strength
            var passwordCriteria = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
            if (!passwordCriteria.IsMatch(member.Password))
            {
                ModelState.AddModelError("Password", "Password is not strong enough.");
                ViewBag.ConsoleMessage = "Password not strong enough.";
                return View(member);
            }

            // Step 5: If the form is valid, add new member and redirect
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();

                // Redirect to User page after successful signup
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ConsoleMessage = "Member not valid.";
            }

            return View(member);
        }

        // reCAPTCHA validation method
        private async Task<bool> ValidateRecaptcha(string gRecaptchaRes)
        {
            var client = new HttpClient();
            var secretKey = "6Ld32FcqAAAAAOWxV7HPcLN8Ll7E2i7A_YK03VT-"; 
            var res = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={gRecaptchaRes}");

            var result = JObject.Parse(res);

            return result["success"].Value<bool>();
        }
    }
}

