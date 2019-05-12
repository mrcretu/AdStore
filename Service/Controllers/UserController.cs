using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}