using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDemo2023.Controllers
{
    public class TotoController : Controller
    {
        public IActionResult Index()
        {
            string toto = "salut";
            return View();
        }
    }
}
