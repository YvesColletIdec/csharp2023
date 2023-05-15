using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ILogger<CategorieController> _logger;
        private SqlServerContext _con;

        public CategorieController(ILogger<CategorieController> logger, SqlServerContext connection)
        {
            _logger = logger;
            _con = connection;
        }

        public IActionResult Index()
        {
            List<Categorie> listeCat = _con.Categories.ToList();
            return View(listeCat);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie c)
        {
            if (ModelState.IsValid)
            {
                _con.Categories.Add(c);
                _con.SaveChanges();
                TempData["message"] = "youpie la catégorie est ajoutée";
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}
