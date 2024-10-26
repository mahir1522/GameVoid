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
            var member = await _context.Members
                .Include( m => m.Addresses)
                .FirstOrDefaultAsync(m => m.MemberID == memberId);

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

                return View(existingMember);
            }

            TempData["ErrorMessage"] = "Your account is not edited.";
            return View(member);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEditAddress(int memberId, int? addressId)
        {
            var member = await _context.Members.Include(m => m.Addresses).FirstOrDefaultAsync(m => m.MemberID == memberId);

            if (member == null)
            {
                return NotFound();
            }

            Address address;
            if (addressId == null) // Adding a new address
            {
                address = new Address(); // Create a new Address object
            }
            else // Editing an existing address
            {
                address = member.Addresses.FirstOrDefault(a => a.AddressID == addressId);
                if (address == null)
                {
                    return NotFound(); // Address not found
                }
            }

            return View(address); // Pass a single Address object to the view
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditAddress(Address address)
        {
            // Ensure the MemberID is set
            if (address.MemberID == 0) // Assuming you get this from the profile page
            {
                // Optionally, handle this case, maybe redirect or set an error
                ModelState.AddModelError("", "MemberID is required.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (address.AddressID == 0) // Adding a new address
                    {
                        _context.Address.Add(address);
                    }
                    else // Editing an existing address
                    {
                        _context.Address.Update(address);
                    }

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Address has been saved successfully.";
                    return View(address);
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"There was an error saving the address: {ex.Message}";
                }
            }

            // Return the view with the invalid model state
            return View(address);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAddress(int memberId, int addressId)
        {
            var address = await _context.Address.FindAsync(addressId);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Address has been deleted successfully.";
            return RedirectToAction("Profile", new { memberId });
        }

    }
}