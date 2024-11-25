using Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;

namespace PROG3050_Team_Project.Controllers
{
    public class ReviewController : Controller
    {
        private readonly GameVoidContext _context;

        public ReviewController(GameVoidContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int memberId, int gameId)
        {
            var game = await _context.Games
            .Include(g => g.Reviews)
            .FirstOrDefaultAsync(g => g.GameID == gameId);

            if (game == null) return NotFound();

            var userReview = game.Reviews.FirstOrDefault(r => r.MemberId == memberId);
            
            var viewModel = new GameReviewViewModel
            {
                game = game,
                MemberID = memberId,
                reviews = game.Reviews.Where(r => r.ReviewStatus == "Approved").ToList(),
                UserReview = userReview
            };

            return View(viewModel);
        }

        // POST: Add a new review
        [HttpPost]
        public async Task<IActionResult> AddReview(GameReviewViewModel viewModel, int memberId)
        {
            if (viewModel.NewReview.ReviewText == null || viewModel.NewReview.ReviewText.Length < 5) 
            {
                TempData["Alert"] = "Your Review should have atleast 5 characters.";
                return RedirectToAction("Index", "Review", new { memberId, gameId = viewModel.game.GameID });
            }

            var review = new Review
            {
                GameId = viewModel.game.GameID,
                MemberId = memberId, // Replace with the logged-in user's ID
                ReviewText = viewModel.NewReview.ReviewText,
                ReviewDate = DateTime.Now,
                ReviewStatus = "Pending" // Default to unapproved
            };

            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Your review has been submitted and is pending approval.";
            return RedirectToAction("Index", "Review", new { memberId, gameId = viewModel.game.GameID });
        }
    }
}
