using Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Connect(string utilisateur, string mdp) {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("~/Home/Index");

            Utilisateur u = _context.Utilisateurs.FirstOrDefault(
                x => x.Login == utilisateur && x.EstActif);
            if (u == null)
            {
                TempData["MessageKO"] = "la connexion a échouée";
            }
             else
            {
                if (Security.Verify(mdp, u.MotDePasse))
                {
                    TempData["MessageOK"] = "la connexion a réussie";

                    string claimRole = u.Role;

                    var userClaims = new[] {
                        new Claim(ClaimTypes.Name, utilisateur),
                        new Claim(ClaimTypes.Role, claimRole),
                        new Claim("Id", u.Id.ToString()),
                        new Claim("Role", claimRole)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims, "custom");

                    ClaimsPrincipal userPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });
                    HttpContext.User = userPrincipal;
                    HttpContext.SignInAsync(userPrincipal);

                    HttpContext.Session.SetString("id", Convert.ToString(u.Id));
                    HttpContext.Session.SetString("userName", utilisateur);
                } else
                {
                    TempData["MessageKO"] = "la connexion a échouée";
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
