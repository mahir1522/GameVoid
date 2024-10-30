using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using System.Threading.Tasks;
using System.Linq;

namespace PROG3050_Team_Project.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly GameVoidContext _context;

        public WishlistController(GameVoidContext context)
        {
            _context = context;
        }

        // Display the wishlist for a given member
        public async Task<IActionResult> List(int memberId)
        {
            var wishlist = await _context.WishLists
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (wishlist == null)
            {
                wishlist = new WishList { MemberID = memberId };
                _context.WishLists.Add(wishlist);
                await _context.SaveChangesAsync();
            }

            return View(wishlist);
        }

        // Add a game to the wishlist
        [HttpPost]
        public async Task<IActionResult> AddToWishlist(int memberId, int gameId)
        {
            var wishlist = await _context.WishLists
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (wishlist == null)
            {
                wishlist = new WishList { MemberID = memberId };
                _context.WishLists.Add(wishlist);
            }

            var game = await _context.Games.FindAsync(gameId);
            if (game != null && !wishlist.Games.Contains(game))
            {
                wishlist.AddToWishList(game);
                await _context.SaveChangesAsync();
                return View();
            }

            return BadRequest();
        }

        //public async Task<IActionResult> AddToWishlist(int memberId, int gameId)
        //{
        //    var wishlist = await _context.WishLists
        //        .Include(w => w.Games)
        //        .FirstOrDefaultAsync(w => w.MemberID == memberId);

        //    if (wishlist == null)
        //    {
        //        wishlist = new WishList { MemberID = memberId };
        //        _context.WishLists.Add(wishlist);
        //    }

        //    var game = await _context.Games.FindAsync(gameId);
        //    if (game != null && !wishlist.Games.Contains(game))
        //    {
        //        wishlist.AddToWishList(game);
        //        await _context.SaveChangesAsync();
        //        TempData["SuccessMessage"] = "Game added to wishlist successfully.";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Game could not be added to wishlist.";
        //    }

        //    return RedirectToAction("Index", new { memberId });
        //}

        // Remove a game from the wishlist
        public async Task<IActionResult> RemoveFromWishlist(int memberId, int gameId)
        {
            var wishlist = await _context.WishLists
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            var game = wishlist?.Games.FirstOrDefault(g => g.GameID == gameId);

            if (game != null)
            {
                wishlist.RemoveFromWishList(game);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Game removed from wishlist successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Game could not be found in wishlist.";
            }

            return RedirectToAction("Index", new { memberId });
        }
    }
}


