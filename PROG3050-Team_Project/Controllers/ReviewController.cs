using Google;
using Google.Cloud.RecaptchaEnterprise.V1;
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
        [HttpGet]
        public async Task<IActionResult> Ratings(int gameId, int memberId)
        {
            var ratings = await _context.Ratings
            .Where(r => r.GameId == gameId)
            .Select(r => r.Rating)
            .ToListAsync();

            var existingsrating = await _context.Ratings
            .Where(r => r.MemberId == memberId && r.GameId == gameId)
            .Select(r => r.Rating)
            .FirstOrDefaultAsync();

            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberID == memberId);
            var selectedGame = await _context.Games.FirstOrDefaultAsync(m => m.GameID == gameId);
            GameRatingViewModel gameRatingViewModel;

            if (ratings == null || ratings.Count == 0)
            {

                gameRatingViewModel = new GameRatingViewModel
                {
                    Member = member,
                    game = selectedGame,
                    UserRating = existingsrating,
                    AllRatings = ratings,
                    AverageRatings = 0
                };

            }
            else
            {
                gameRatingViewModel = new GameRatingViewModel
                {
                    Member = member,
                    game = selectedGame,
                    UserRating = existingsrating,
                    AllRatings = ratings,
                    AverageRatings = (int)Math.Round(ratings.Average())
                };

            }


            return View(gameRatingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRating(GameRatingViewModel viewModel, int memberId)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberID == memberId);
            var selectedGame = await _context.Games.FirstOrDefaultAsync(m => m.GameID == viewModel.gameId);
            var existingsrating = await _context.Ratings
            .Where(r => r.MemberId == memberId && r.GameId == viewModel.gameId)
            .FirstOrDefaultAsync();

            if(existingsrating != null)
            {
                existingsrating.Rating = viewModel.UserRating;
                _context.Ratings.Update(existingsrating);
            }
            else
            {
                Ratings rates = new Ratings
                {

                    Rating = viewModel.UserRating,
                    MemberId = memberId,
                    GameId = viewModel.gameId
                };

                _context.Ratings.Add(rates);
            }


            await _context.SaveChangesAsync();
            TempData["Message"] = "Your rating has been submitted.";
            return RedirectToAction("Ratings", "Review", new { gameId = viewModel.gameId, memberId = memberId });
        }

        [HttpGet]
        public async Task<IActionResult> EditRating(int gameId, int memberId)
        {
            
            var existingsrating = await _context.Ratings
            .Where(r => r.MemberId == memberId && r.GameId == gameId)
            .FirstOrDefaultAsync();

            existingsrating.Rating = 0;
            _context.Ratings.Update(existingsrating);
            await _context.SaveChangesAsync();

            return RedirectToAction("Ratings", "Review", new { gameId = gameId, memberId = memberId });
        }


        
    }
}
