using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}