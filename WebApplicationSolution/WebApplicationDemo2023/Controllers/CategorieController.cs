using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    [Authorize]
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
                TempData["messageOK"] = "youpie la catégorie est ajoutée";
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public IActionResult Update(int id)
        {
            //Categorie c = _con.Categories.Find(id);
            Categorie c = _con.Categories.FirstOrDefault(c => c.Id == id);
            if (c == null)
            {
                TempData["messageKO"] = "la catégorie souhaitée n'existe pas";
                return RedirectToAction("Index");
            } else {
                return View(c);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Categorie c)
        {
            if (ModelState.IsValid)
            {
                _con.Categories.Update(c);
                _con.SaveChanges();
                TempData["messageOK"] = "youpie la catégorie est modifiée";
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}
