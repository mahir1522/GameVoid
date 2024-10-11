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
        public async Task<IActionResult> Profile(Member member, IFormFile profileImage)
        {
            if (ModelState.IsValid)
            {
                var existingMember = await _context.Members.FindAsync(member.MemberID);
                if (existingMember != null)
                {
                    // Update member properties
                    existingMember.FullName = member.FullName;
                    existingMember.Gender = member.Gender;
                    existingMember.BirthDate = member.BirthDate;
                    existingMember.WantsPromotions = member.WantsPromotions;

                    // Handle the profile image upload
                    if (profileImage != null && profileImage.Length > 0)
                    {
                        // Assuming you save the image in a folder and store the path in the database
                        var filePath = Path.Combine("wwwroot/img", profileImage.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await profileImage.CopyToAsync(stream);
                        }
                        existingMember.profileImage = $"/img/{profileImage.FileName}"; 
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { memberId = existingMember.MemberID });

                }
            }
            return RedirectToAction("Index", "User");
        }

    }
}
