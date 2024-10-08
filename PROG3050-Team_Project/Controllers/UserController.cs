using Microsoft.AspNetCore.Mvc;
using PROG3050_Team_Project.Models;
using PROG3050_Team_Project.Services;

namespace PROG3050_Team_Project.Controllers
{

    public class UserController : Controller
    {
        private readonly GameVoidContext _context;



        public UserController(GameVoidContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int memberId)
        {
            var user = await _context.Members.FindAsync(memberId);
            if (user == null)
            {
                return NotFound();
            }
            var games = _context.Games.ToList();

            var userGamesViewModel = new MemberGamesViewModel
            {
                member = user,
                games = games
            };
            return View(userGamesViewModel);
        }
    }
}
