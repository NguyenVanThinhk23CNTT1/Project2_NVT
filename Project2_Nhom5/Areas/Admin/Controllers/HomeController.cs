using Microsoft.AspNetCore.Mvc;
using Project2_Nhom5.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Project2_Nhom5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Project2_Nhom5Context _context;

        public HomeController(ILogger<HomeController> logger, Project2_Nhom5Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get statistics
            var movieCount = await _context.Movies.CountAsync();
            var theaterCount = await _context.Theaters.CountAsync();
            var showtimeCount = await _context.Showtimes.CountAsync();
            var ticketCount = await _context.Tickets.CountAsync();

            // Pass statistics to view
            ViewBag.MovieCount = movieCount;
            ViewBag.TheaterCount = theaterCount;
            ViewBag.ShowtimeCount = showtimeCount;
            ViewBag.TicketCount = ticketCount;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
