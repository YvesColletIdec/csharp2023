using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDemo2023.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
