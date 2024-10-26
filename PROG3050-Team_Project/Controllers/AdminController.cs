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
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Game game)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Model is invalid. Please check the inputs.";
                return View(game);
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Game has been successfully added.";
            return View(game);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Getting the selected games data by fetching id
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Game game)
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
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
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
    }
}
