using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using System.Text.RegularExpressions;

namespace PROG3050_Team_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly GameVoidContext _context;
        public AdminController(GameVoidContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieving all games from Games table
            var games = _context.Games.ToList();
            return View(games);

            // Retrieving all games from Games table
            var eve = _context.Events.ToList();
            return View(games);
        }
        public IActionResult Reports()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Event()
        {
            // Retrieving all games from Games table
            var eve = _context.Events.ToList();
            return View(eve);
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Model is invalid. Please check the inputs.";
                return View(game);
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Game has been successfully added.";
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(Event eve)
        {
            // Checking if game passes all inputs
            if (!ModelState.IsValid)
            {
                ViewBag.ConsoleMessage = "Model is invalid. Please check the inputs.";
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    ViewBag.ConsoleMessage = $"Model Error: {error.ErrorMessage}";
                }
                return View(eve);
            }

            // Adding game to table if game is valid
            if (ModelState.IsValid)
            {
                _context.Events.Add(eve);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Event has been successfully added.";
                return RedirectToAction("Event", "Admin");
            }
            else
            {
                ViewBag.ConsoleMessage = "Event not valid.";
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditGame(int id)
        {
            // Getting the selected games data by fetching id
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            // Getting the selected games data by fetching id
            var eve = _context.Events.Find(id);
            if (eve == null)
            {
                return NotFound();
            }
            return View(eve);
        }

        [HttpPost]
        public async Task<IActionResult> EditGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid input. Please check the inputs.";
                return View(game);
            }

            _context.Attach(game);
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Game has been successfully edited.";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(Event eve)
        {
            // Tracks the existing game and modifies it based on the inputs
            if (ModelState.IsValid)
            {
                _context.Attach(eve);
                _context.Entry(eve).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Game has been successfully edited.";
                return RedirectToAction("Index", "Admin");

            }
            else
            {
                ViewBag.ConsoleMessage = "Inavlid input.";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGame(int id)
        {
            // Getting game based on id and deleting it from database
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                TempData["ErrorMessage"] = "Game not found.";
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Game has been successfully deleted.";


            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            // Getting game based on id and deleting it from database
            var eve = await _context.Events.FindAsync(id);
            if (eve == null)
            {
                TempData["ErrorMessage"] = "Game not found.";
                return NotFound();
            }
            _context.Events.Remove(eve);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Event has been successfully deleted.";


            return RedirectToAction("Index", "Admin");
        }


        
        public async Task<IActionResult> Order()
        {
            var orders = await _context.Orders
                .Include(o => o.Games)
                .ThenInclude(oi => oi.Orders)
                .ToListAsync();


            if (orders == null || !orders.Any())
            {
                TempData["InfoMessage"] = "No Order found.";
            }

            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> ProcessedOrder(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Member)
                .Include(o => o.Games)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            order.OrderStatus = "Processed";

            var orders = await _context.Orders
                .Include(o => o.Games)
                .ThenInclude(oi => oi.Orders)
                .ToListAsync();


            if (orders == null || !orders.Any())
            {
                TempData["InfoMessage"] = "No purchases found for this user.";
            }

            return RedirectToAction("Order", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> Review(int gameId)
        {
            var game = await _context.Games
            .Include(g => g.Reviews)
            .FirstOrDefaultAsync(g => g.GameID == gameId);

            if (game == null) return NotFound();


            var viewModel = new GameReviewViewModel
            {
                game = game,
                reviews = game.Reviews.ToList(),
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ApproveReview(int reviewId)
        {
            var review = await _context.Review.FindAsync(reviewId);

            if (review == null)
            {
                return NotFound();
            }

            // Update the review status to Approved
            review.ReviewStatus = "Approved";

            _context.Review.Update(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Review", new{ gameId = review.GameId });
        }


    }
}
