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
        public async Task<IActionResult> FriendList(int memberId, int friendId)
        {
            var Friend = _context.Members.FirstOrDefault(m => m.MemberID == friendId);
            var member = _context.Members.FirstOrDefault(m => m.MemberID == memberId);
            var allMembers = _context.Members.Where(m => m.MemberID != memberId).ToList();
            var friendWishlist = await _context.WishLists
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == friendId);

            var model = new FriendsViewModel
            {
                CurrentMember = member,
                Friend = Friend,
                AllMembers = allMembers,
                WishList = friendWishlist
            };
            
            return View(model);
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

            TempData["SuccessMessage"] = "Game added to Wishlist successfully.";
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
        [HttpGet]
        public async Task<IActionResult> ShareWishlist(int memberId)
        {
            var wishlist = await _context.WishLists
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (wishlist == null || !wishlist.Games.Any())
            {
                TempData["ErrorMessage"] = "Your wishlist is empty.";
                return RedirectToAction("Index", "Games");
            }

            // Generate text to share
            var wishlistText = $"Check out my wishlist: " +
                string.Join(", ", wishlist.Games.Select(g => g.Title));

            // Pass the text as a model or ViewBag to your view
            ViewBag.WishlistText = wishlistText;

            return View(wishlistText);
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

            TempData["SuccessMessage"] = "Game added to Cart successfully.";
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
                TempData["SuccessMessage"] = "Game removed from Cart successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Game could not be found in Cart.";
            }

            return RedirectToAction("Cart", new { memberId });
        }

        public async Task<IActionResult> Event(int memberId)
        {
            var user = await _context.Members
                .Include(m => m.MemberEvents)
                    .ThenInclude(me => me.Event)
                .FirstOrDefaultAsync(m => m.MemberID == memberId);

            if (user == null)
            {
                return NotFound();
            }

            var events = await _context.Events.ToListAsync();

            var viewModel = new MemberGamesViewModel
            {
                member = user,
                events = events,
                IsRegistered = false
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterForEvent(int memberId, int eventId)
        {
            var memberEventExists = await _context.MemberEvents
                .AnyAsync(me => me.MemberId == memberId && me.EventId == eventId);

            if (!memberEventExists)
            {
                var memberEvent = new MemberEvent
                {
                    MemberId = memberId,
                    EventId = eventId
                };

                _context.MemberEvents.Add(memberEvent);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "You have successfully registered for the event.";
            }
            else
            {
                TempData["WarningMessage"] = "You are already registered for this event.";
            }

            return RedirectToAction("Event", new { memberId });
        }

        public async Task<IActionResult> RegisteredEvent(int memberId)
        {
            var user = await _context.Members
                .Include(m => m.MemberEvents)
                    .ThenInclude(me => me.Event)
                .FirstOrDefaultAsync(m => m.MemberID == memberId);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new MemberGamesViewModel
            {
                member = user,
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Unregister(int eventId, int memberId)
        {
            // Find the registration entry for this member and event
            var memberEvent = _context.MemberEvents
                .FirstOrDefault(me => me.EventId == eventId && me.MemberId == memberId);

            if (memberEvent != null)
            {
                // Remove the entry from the database to unregister the member from the event
                _context.MemberEvents.Remove(memberEvent);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "You have been unregistered from the event.";
            }
            else
            {
                TempData["ErrorMessage"] = "You were not registered for this event.";
            }

            return RedirectToAction("RegisteredEvent", new { memberId = memberId });
        }

        [HttpGet]
        public async Task<IActionResult> Checkout(int memberId)
        {
            var cart = await _context.Carts
                .Include(w => w.Games)
                .FirstOrDefaultAsync(w => w.MemberID == memberId);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitCheckout(int memberId, string CardHolderName, string CardNumber, int ExpirationMonth, int ExpirationYear, string CVC)
        {
            var cart = await _context.Carts
                            .Include(w => w.Games)
                            .FirstOrDefaultAsync(w => w.MemberID == memberId);

            if (cart == null || !cart.Games.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty.";
                return RedirectToAction("Checkout", new { memberId });
            }

            var order = new Order
            {
                MemberID = memberId,
                Member = await _context.Members.FindAsync(memberId),
                Games = cart.Games.ToList(),
                TotalAmount = cart.Games.Sum(g => g.Price),
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };

            // Save the order to the database
            _context.Orders.Add(order);

            // Clear the wishlist after checkout
            cart.Games.Clear();
            _context.Carts.Update(cart);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your order has been successfully placed!";
            return RedirectToAction("OrderDetails", new { orderId = order.OrderId });
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Member)
                .Include(o => o.Games)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> UserPurchases(int memberId)
        {
            var orders = await _context.Orders
                .Include(o => o.Games)
                    .ThenInclude(oi => oi.Orders)
                .Where(o => o.MemberID == memberId)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                TempData["InfoMessage"] = "No purchases found for this user.";
            }

            return View(orders);
        }
        public IActionResult DownloadGameFile()
        {
            // Define the path of the file to download (replace with your actual file logic if per game)
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "GameInfo.txt");

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = "File not found.";
                return RedirectToAction("UserPurchases");  // Replace with the page you want to redirect to if the file is missing
            }

            // Set file name for download
            var fileName = "GameInfo.txt";  // Customize based on the game, if needed

            // Return the file as a download
            return PhysicalFile(filePath, "application/octet-stream", fileName);
        }

        
    }
}


