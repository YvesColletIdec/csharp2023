using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private SqlServerContext _con;

        public ClientController(ILogger<ClientController> logger, SqlServerContext connection)
        {
            _logger = logger;
            _con = connection;
        }

        private void LoadListNPA()
        {
            List<string> listNpa = _con.Clients.Select(x => x.Npa).ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string npa in listNpa)
            {
                SelectListItem item = new SelectListItem();
                item.Text = npa;
                item.Value = npa;
                list.Add(item);
            }
            
            ViewBag.ListNPA = list;
        }


        public IActionResult Index()
        {
            List<Client> listeCli = _con.Clients.ToList();
            return View(listeCli);
        }

        public IActionResult Create()
        {
            LoadListNPA();
            return View("Update", new Client() { Id = 0});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client c)
        {
            if (ModelState.IsValid)
            {
                _con.Clients.Add(c);
                _con.SaveChanges();
                TempData["messageOK"] = "youpie le client est ajoutée";
                return RedirectToAction("Index");
            }
            return View("Update", c);
        }

        public IActionResult Update(int id)
        {
            Client c = _con.Clients.FirstOrDefault(c => c.Id == id);
            if (c == null)
            {
                TempData["messageKO"] = "le client souhaité n'existe pas";
                return RedirectToAction("Index");
            } else {
                LoadListNPA();
                return View(c);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Client c)
        {
            if (ModelState.IsValid)
            {
                _con.Clients.Update(c);
                _con.SaveChanges();
                TempData["messageOK"] = "youpie le client est modifié";
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}
