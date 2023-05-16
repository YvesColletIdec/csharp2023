using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    public class LoginController : Controller
    {
        private SqlServerContext _context = null;

        public LoginController(SqlServerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Connect(string utilisateur, string mdp) {
            Utilisateur u = _context.Utilisateurs.FirstOrDefault(
                x => x.Login == utilisateur && x.MotDePasse == mdp
                && x.EstActif);
            if (u == null)
            {
                TempData["MessageKO"] = "la connexion a échouée";
            }
             else
            {
                TempData["MessageOK"] = "la connexion a réussie";
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
