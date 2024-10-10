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
            // Checking if game passes all inputs
            if (!ModelState.IsValid)
            {
                ViewBag.ConsoleMessage = "Model is invalid. Please check the inputs.";
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    ViewBag.ConsoleMessage = $"Model Error: {error.ErrorMessage}";
                }
                return View(game);
            }

            // Adding game to table if game is valid
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ConsoleMessage = "Game not valid.";
            }

            return View();
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
            if (ModelState.IsValid)
            {
                _context.Attach(game);
                _context.Entry(game).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ConsoleMessage = "Game not valid.";
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // Getting game based on id and deleting it from database
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Admin");
        }
    }
}
