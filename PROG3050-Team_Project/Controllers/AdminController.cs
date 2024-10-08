using Microsoft.AspNetCore.Mvc;
using PROG3050_Team_Project.Models;

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
