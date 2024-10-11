using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using PROG3050_Team_Project.Services;

namespace PROG3050_Team_Project.Controllers
{

    public class UserController : Controller
    {
        private readonly GameVoidContext _context;
        public UserController(GameVoidContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int memberId)
        {
            var user = await _context.Members.FindAsync(memberId);
            if (user == null)
            {
                return NotFound();
            }
            var games = _context.Games.ToList();

            var userGamesViewModel = new MemberGamesViewModel
            {
                member = user,
                games = games
            };
            return View(userGamesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int memberId)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberID == memberId);

            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(Member member, IFormFile? ProfileImage)
        {
            var existingMember = await _context.Members.FindAsync(member.MemberID);

            if (existingMember == null)
            {
                // Return error or handle null case
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update member properties
                existingMember.FullName = member.FullName;
                existingMember.Gender = member.Gender;
                existingMember.BirthDate = member.BirthDate;
                existingMember.WantsPromotions = member.WantsPromotions;

                // Handle the profile image upload
                if (ProfileImage != null && ProfileImage.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot/img", ProfileImage.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfileImage.CopyToAsync(stream);
                    }
                    existingMember.profileImage = $"/img/{ProfileImage.FileName}";
                }

                // Explicitly mark the member as modified
                _context.Entry(existingMember).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "User has been successfully Edited.";

                return RedirectToAction("Index", new { memberId = existingMember.MemberID });
            }

            TempData["ErrorMessage"] = "Your account is not edited.";
            return RedirectToAction("Index", new { memberId = existingMember.MemberID });
        }
    }
}
