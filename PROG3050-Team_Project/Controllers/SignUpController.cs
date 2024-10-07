using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender _emailSend;

        public SignUpController(GameVoidContext context, IEmailSender emailSend)
        {
            _context = context;
            _emailSend = emailSend;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Member());
        }


        [HttpPost]
        public async Task<IActionResult> Index(Member member, string gRecaptchaRes)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
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

            // Step 3: Validate Email Format
            if (!IsValidEmail(member.Email))
            {
                ModelState.AddModelError("Email", "Please enter a valid email address.");
                ViewBag.ConsoleMessage = "Invalid email format.";
                return View(member);
            }

            // Step 4: Check for existing user by email
            var existingMember = await _context.Members
                .FirstOrDefaultAsync(m => m.Email == member.Email); // Check by Email

            if (existingMember != null)
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                ViewBag.ConsoleMessage = "Email already registered.";
                return View(member);
            }

            // Step 5: Validate the password strength
            var passwordCriteria = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
            if (!passwordCriteria.IsMatch(member.Password))
            {
                ModelState.AddModelError("Password", "Password is not strong enough.");
                ViewBag.ConsoleMessage = "Password not strong enough.";
                return View(member);
            }

            // Step 6: If the form is valid, add new member and redirect
            if (ModelState.IsValid)
            {

                    _context.Members.Add(member);
                    await _context.SaveChangesAsync();

                    var confirmEmailLink = Url.Action(nameof(ConfirmEmail), "SignUp", new { memberId = member.MemberID }, Request.Scheme);

                    await _emailSend.SendEmailAsync(member.Email, "Confirm your email",
                    $"Please confirm your account by clicking this link: <a href='{confirmEmailLink}'>link</a>");

                    TempData["VerificationMessage"] = "A verification link has been sent to your email. Please verify your account.";

                    // Redirect to login page after successful signup
                    return RedirectToAction("Index", "Login");


            }
            else
            {
                ViewBag.ConsoleMessage = "Member not valid.";
            }

            return View(member);
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IActionResult> ConfirmEmail(int memberId)
        {

            if (memberId == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            var member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return NotFound();
            }

            member.IsEmailVerified = true;
            _context.Update(member);
            await _context.SaveChangesAsync();

            TempData["AccountConfirmed"] = "Your account has been successfully confirmed. You can now log in.";
            return RedirectToAction("Index", "Login");
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

