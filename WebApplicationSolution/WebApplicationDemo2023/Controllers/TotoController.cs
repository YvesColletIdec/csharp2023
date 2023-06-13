using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023.Controllers
{
    [Authorize]
    public class TotoController : Controller
    {
        public IActionResult Index()
        {
            string toto = "salut";
            return View();
        }
    }
}
