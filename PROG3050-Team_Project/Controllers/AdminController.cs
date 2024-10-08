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
                ViewBag.ConsoleMessage = "Model is invalid. Please check the inputs.";
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    ViewBag.ConsoleMessage = $"Model Error: {error.ErrorMessage}";
                }
                return View(game);
            }


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
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
