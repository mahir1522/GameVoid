using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using PROG3050_Team_Project.Services;
using System.Dynamic;

namespace PROG3050_Team_Project.Controllers
{

    public class UserController : Controller
    {
        private readonly GameVoidContext _context;
        public UserController(GameVoidContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int memberId, string filter)
        {
            var user = await _context.Members.FindAsync(memberId);
            if (user == null)
            {
                return NotFound();
            }

            // Fetch games based on the filter
            var games = filter switch
            {
                "Top" => _context.Games.OrderByDescending(g => g.Rating).ToList(),
                "Popular" => _context.Games.OrderByDescending(g => g.ReleaseDate).ToList(),
                "Recommended" => _context.Games
                                .Where(g => g.Category == user.FavoriteGameCategories)
                                .ToList(),
                _ => _context.Games.ToList() // Default: return all games
            };

            var userGamesViewModel = new MemberGamesViewModel
            {
                member = user,
                games = games,
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



            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Check the output or log
                }
            }



            if (ModelState.IsValid)
            {
                // Update member properties
                existingMember.FullName = member.FullName;
                existingMember.Gender = member.Gender;
                existingMember.BirthDate = member.BirthDate;
                existingMember.FavoriteGameCategories = member.FavoriteGameCategories;
                existingMember.FavoritePlatforms = member.FavoritePlatforms;
                existingMember.PreferLanguage = member.PreferLanguage;
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

            Address address = addressId == null ? new Address { MemberID = memberId } : member.Addresses.FirstOrDefault(a => a.AddressID == addressId);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }


        [HttpPost]
        public async Task<IActionResult> AddOrEditAddress(Address address)
        {
            if (address.MemberID == 0)
            {
                ModelState.AddModelError("", "MemberID is required.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (address.AddressID == 0)
                    {
                        _context.Address.Add(address);
                    }
                    else
                    {
                        _context.Address.Update(address);
                    }

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Address has been saved successfully.";
                    return RedirectToAction("Profile", new { memberId = address.MemberID });
                }
                catch (DbUpdateException dbEx)
                {
                    ModelState.AddModelError("", $"Database error: {dbEx.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Unexpected error: {ex.Message}");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
            }

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

        public IActionResult Search(string query, int memberId)
        {
            var member = _context.Members.FirstOrDefault(m => m.MemberID == memberId); // Get member based on ID

            var viewModel = new MemberGamesViewModel
            {
                member = member, // Set the member in the view model
                games = _context.Games
                    .Where(g => string.IsNullOrEmpty(query) || g.Title.Contains(query) || g.Description.Contains(query))
                    .ToList()
            };

            return View("Index", viewModel); // Return the filtered games with member info
        }

        // Redirect to Friends Page
        public IActionResult GoToFriends(int memberId)
        {
            return RedirectToAction("Friends", new { memberId });
        }

        // Friends Page Action
        // Display Friends and All Members
        public IActionResult Friends(int memberId)
        {
            // Get the current member
            var currentMember = _context.Members.Include(m => m.FriendsAndFamily)
                                                 .FirstOrDefault(m => m.MemberID == memberId);

            if (currentMember == null)
            {
                return NotFound();
            }

            // Get all members excluding the current member
            var allMembers = _context.Members.Where(m => m.MemberID != memberId).ToList();

            // Create a ViewModel or use the Member model directly
            var viewModel = new FriendsViewModel
            {
                CurrentMember = currentMember,
                AllMembers = allMembers
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AddFriend(int memberId, int friendId)
        {
            // Find the current member and the friend to add
            var currentMember = _context.Members.Include(m => m.FriendsAndFamily).FirstOrDefault(m => m.MemberID == memberId);
            var friendMember = _context.Members.Include(m => m.FriendsAndFamily).FirstOrDefault(m => m.MemberID == friendId);

            if (currentMember == null || friendMember == null)
            {
                return NotFound("One of the members was not found.");
            }

            // Check if they are already friends
            if (!currentMember.FriendsAndFamily.Any(f => f.MemberID == friendId))
            {
                // Add each member to the other’s friends list for a mutual friendship
                currentMember.FriendsAndFamily.Add(friendMember);
                friendMember.FriendsAndFamily.Add(currentMember);

                _context.SaveChanges();
            }

            return RedirectToAction("Friends", new { memberId = memberId });
        }

        // Remove Friend Action
        [HttpPost]
        public IActionResult RemoveFriend(int memberId, int friendId)
        {
            // Retrieve both members involved in the friendship
            var currentMember = _context.Members.Include(m => m.FriendsAndFamily).FirstOrDefault(m => m.MemberID == memberId);
            var friendMember = _context.Members.Include(m => m.FriendsAndFamily).FirstOrDefault(m => m.MemberID == friendId);

            if (currentMember == null || friendMember == null)
            {
                return NotFound("One of the members was not found.");
            }

            // Remove each other from the friends list
            if (currentMember.FriendsAndFamily.Any(f => f.MemberID == friendId))
            {
                currentMember.FriendsAndFamily.Remove(friendMember);
            }
            if (friendMember.FriendsAndFamily.Any(f => f.MemberID == memberId))
            {
                friendMember.FriendsAndFamily.Remove(currentMember);
            }

            // Save changes to the database
            _context.SaveChanges();

            return RedirectToAction("Friends", new { memberId = memberId });
        }


        public IActionResult SearchFriends(int memberId, string query)
        {
            // Check if memberId and query are valid
            if (string.IsNullOrWhiteSpace(query))
            {
                ModelState.AddModelError("", "Search query cannot be empty.");
                return View(new FriendsViewModel()); // Return an empty view model
            }

            // Find the current member with friends
            var currentMember = _context.Members
                .Include(m => m.FriendsAndFamily)
                .FirstOrDefault(m => m.MemberID == memberId);

            if (currentMember == null)
            {
                return NotFound("Member not found.");
            }

            // Search all members by UserName, excluding the current member
            var allMembers = _context.Members
                .Where(m => m.MemberID != memberId && m.UserName.Contains(query))
                .ToList();

            // Set up the FriendsViewModel
            var viewModel = new FriendsViewModel
            {
                CurrentMember = currentMember,
                AllMembers = allMembers
            };

            return View("Friends", viewModel); // Ensure this matches your view's name
        }

    }
}