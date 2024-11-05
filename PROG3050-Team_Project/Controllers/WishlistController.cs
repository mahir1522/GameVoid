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
            // Check if the member exists
            var member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                return NotFound("Member does not exist.");
            }

            // Check if the game exists
            var game = await _context.Games.FindAsync(gameId);
            if (game == null)
            {
                return NotFound("Game does not exist.");
            }

            // Create a new wishlist or add to an existing one
            var wishList = await _context.WishLists
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (wishList == null)
            {
                wishList = new WishList
                {
                    MemberID = memberId,
                    Member = member
                };
                _context.WishLists.Add(wishList);
            }

            wishList.Games.Add(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", new { memberId });

            //var wishlist = await _context.WishLists
            //    .Include(w => w.Games)
            //    .FirstOrDefaultAsync(w => w.MemberID == memberId);

            //if (wishlist == null)
            //{
            //    wishlist = new WishList { MemberID = memberId };
            //    _context.WishLists.Add(wishlist);
            //}

            //var game = await _context.Games.FindAsync(gameId);
            //if (game != null && !wishlist.Games.Contains(game))
            //{
            //    wishlist.AddToWishList(game);
            //    await _context.SaveChangesAsync();
            //    TempData["SuccessMessage"] = "Game has been successfully added to your wishlist.";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "Game could not be added to the wishlist.";
            //}

            //return RedirectToAction("List", "Wishlist");
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

            return RedirectToAction("List", new { memberId });
        }
        public IActionResult ShareWishlist(int memberId)
        {
            // Generate a shareable URL, e.g., /wishlist/view/1
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            string shareUrl = $"{baseUrl}/wishlist/view/{memberId}";

            // Pass the URL to the view or share logic
            return View("ShareWishlist", new { ShareUrl = shareUrl });
        }

        public async Task<IActionResult> Cart(int memberId)
        {
            var cart = await _context.Carts
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (cart == null)
            {
                cart = new Cart { MemberID = memberId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            return View(cart);
        }

        // Add a game to the wishlist
        [HttpPost]
        public async Task<IActionResult> AddToCart(int memberId, int gameId)
        {
            // Check if the member exists
            var member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                return NotFound("Member does not exist.");
            }

            // Check if the game exists
            var game = await _context.Games.FindAsync(gameId);
            if (game == null)
            {
                return NotFound("Game does not exist.");
            }

            // Create a new wishlist or add to an existing one
            var cart = await _context.Carts
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (cart == null)
            {
                cart = new Cart
                {
                    MemberID = memberId,
                    Member = member
                };
                _context.Carts.Add(cart);
            }

            cart.Games.Add(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("Cart", new { memberId });
        }

        public async Task<IActionResult> RemoveFromCart(int memberId, int gameId)
        {
            var cart = await _context.Carts
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            var game = cart?.Games.FirstOrDefault(g => g.GameID == gameId);

            if (game != null)
            {
                cart.RemoveFromCart(game);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Game removed from wishlist successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Game could not be found in wishlist.";
            }

            return RedirectToAction("Cart", new { memberId });
        }

        public async Task<IActionResult> Event(int memberId)
        {

            var user = await _context.Members.FindAsync(memberId);
            if (user == null)
            {
                return NotFound();
            }
            var games = _context.Games.ToList();
            var events = await _context.Events.ToListAsync();

            var viewModel = new MemberGamesViewModel
            {
                member = user,
                games = games,
                events = events,
                IsRegistered = false
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(int eventId, int memberId)
        {
            var member = _context.Members
                .Include(m => m.RegisteredEvents)
                .FirstOrDefault(m => m.MemberID == memberId);
            var eventToRegister = _context.Events.FirstOrDefault(e => e.EventId == eventId);

            if (member != null && eventToRegister != null && !member.RegisteredEvents.Contains(eventToRegister))
            {
                member.RegisteredEvents.Add(eventToRegister);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "You have successfully registered for the event.";
            }

            return RedirectToAction("Event", new { memberId = memberId });
        }
    }
}


