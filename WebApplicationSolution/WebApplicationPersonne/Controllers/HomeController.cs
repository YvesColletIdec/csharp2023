using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationPersonne.Models;

namespace WebApplicationPersonne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqlServerContext _context;

        public HomeController(ILogger<HomeController> logger, SqlServerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult MonAction(int a, int b)
        {
            Console.WriteLine(a + b);
            return null;
        }

        public IActionResult Index()
        {
            Console.WriteLine(_context.Personnes.Count());
            return View();
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