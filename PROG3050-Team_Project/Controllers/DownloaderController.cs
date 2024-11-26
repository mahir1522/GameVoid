using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PROG3050_Team_Project.Models;
using System.Text;

namespace PROG3050_Team_Project.Controllers
{
    public class DownloaderController : Controller
    {
        private readonly GameVoidContext _context;

        public DownloaderController(GameVoidContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> DownloadGameFile(int gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.GameID == gameId);

            if (game == null)
            {
                TempData["ErrorMessage"] = "Game not found.";
                return RedirectToAction("UserPurchases");
            }

            // Create the content for the text file
            string fileContent = $"Game Name: {game.Title}\nDescription: {game.Description}\nPrice: {game.Price}\n";

            // Convert the string content to a byte array
            var fileBytes = System.Text.Encoding.UTF8.GetBytes(fileContent);

            // Return the file as a downloadable .txt file
            return File(fileBytes, "text/plain", $"{game.Title}.txt");
        }
        // Game List Report
        [HttpGet]
        public async Task<IActionResult> DownloadGameListReport()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context

            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Game List");

            var games = await _context.Games.ToListAsync();
            sheet.Cells[1, 1].Value = "Name";
            sheet.Cells[1, 2].Value = "Description";
            sheet.Cells[1, 3].Value = "Price";

            for (int i = 0; i < games.Count; i++)
            {
                sheet.Cells[i + 2, 1].Value = games[i].Title;
                sheet.Cells[i + 2, 2].Value = games[i].Description;
                sheet.Cells[i + 2, 3].Value = games[i].Price;
            }

            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "GameListReport.xlsx");
        }

        // Member List Report
        [HttpGet]
        public async Task<IActionResult> DownloadMemberListReport()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context

            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Member List");

            var members = await _context.Members.ToListAsync();
            sheet.Cells[1, 1].Value = "Full Name";
            sheet.Cells[1, 2].Value = "Email";
            sheet.Cells[1, 3].Value = "Birth Date";

            for (int i = 0; i < members.Count; i++)
            {
                sheet.Cells[i + 2, 1].Value = members[i].FullName;
                sheet.Cells[i + 2, 2].Value = members[i].Email;
                sheet.Cells[i + 2, 3].Value = members[i].BirthDate;
            }

            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MemberListReport.xlsx");
        }

        // Wish List Report
        [HttpGet]
        public async Task<IActionResult> DownloadWishListReport()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context

            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Wish List");

            var wishLists = await _context.WishLists.Include(w => w.Games).Include(w => w.Member).ToListAsync();
            sheet.Cells[1, 1].Value = "Member";
            sheet.Cells[1, 2].Value = "Game";

            for (int i = 0; i < wishLists.Count; i++)
            {
                sheet.Cells[i + 2, 1].Value = wishLists[i].Member.FullName;
                sheet.Cells[i + 2, 2].Value = wishLists[i].Games.Count;
            }

            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WishListReport.xlsx");
        }

        // Sales Report
        [HttpGet]
        public async Task<IActionResult> DownloadSalesReport()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context

            using var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Sales");

            var orders = await _context.Orders.Include(o => o.Member).Include(o => o.Games).ToListAsync();
            sheet.Cells[1, 1].Value = "Order ID";
            sheet.Cells[1, 2].Value = "Member";
            sheet.Cells[1, 3].Value = "Game";
            sheet.Cells[1, 4].Value = "Price";
            sheet.Cells[1, 5].Value = "Order Date";

            int row = 2;
            foreach (var order in orders)
            {
                foreach (var game in order.Games)
                {
                    sheet.Cells[row, 1].Value = order.OrderId;
                    sheet.Cells[row, 2].Value = order.Member.FullName;
                    sheet.Cells[row, 3].Value = game.Title;
                    sheet.Cells[row, 4].Value = game.Price;
                    sheet.Cells[row, 5].Value = order.OrderDate.ToShortDateString();
                    row++;
                }
            }

            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalesReport.xlsx");
        }
    }
}
