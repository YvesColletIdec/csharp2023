using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    [Authorize(Roles = "admin")]
    public class ArticleController : Controller
    {
        private SqlServerContext _con;

        public ArticleController(SqlServerContext connection)
        {
            _con = connection;
        }

        private void LoadListCategorie()
        {
            List<Categorie> listCat = _con.Categories.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (Categorie cat in listCat)
            {
                SelectListItem item = new SelectListItem();
                item.Text = cat.Nom;
                item.Value = cat.Id.ToString();
                list.Add(item);
            }
            
            ViewBag.ListCAT = list;
        }


        public IActionResult Index()
        {
            List<Article> listeArt = _con.Articles.Include(a => a.Categorie).ToList();
            return View(listeArt);
        }

        public IActionResult Create()
        {
            LoadListCategorie();
            return View("Update", new Article() { Id = 0});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article a)
        {
            if (ModelState.IsValid)
            {
                _con.Articles.Add(a);
                _con.SaveChanges();
                TempData["messageOK"] = "youpie l'article est ajoutée";
                return RedirectToAction("Index");
            }
            return View("Update", a);
        }

        public IActionResult Update(int id)
        {
            Article a = _con.Articles.FirstOrDefault(a => a.Id == id);
            if (a == null)
            {
                TempData["messageKO"] = "l'article souhaité n'existe pas";
                return RedirectToAction("Index");
            } else {
                LoadListCategorie();
                return View(a);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Article a)
        {
            if (ModelState.IsValid)
            {
                _con.Articles.Update(a);
                _con.SaveChanges();
                TempData["messageOK"] = "youpie l'article est modifié";
                return RedirectToAction("Index");
            }
            return View(a);
        }
    }
}
