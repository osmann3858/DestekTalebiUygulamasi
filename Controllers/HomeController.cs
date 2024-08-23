using DestekTalebiUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DestekTalebiUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var destekTalepleri = _context.DestekTalepleri.ToList(); // Veritaban�ndaki destek taleplerini al�yoruz
            return View(destekTalepleri); // Bu destek taleplerini View'a g�nderiyoruz
        }

        public IActionResult Privacy()
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
