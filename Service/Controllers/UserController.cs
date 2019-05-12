using BussinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    public class UserController : Controller
    {
        private IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public IActionResult Index()
        {
            var users = _userLogic.GetAll();
            
            return View(users);
        }

        public IActionResult CreateUser()
        {
            return CreateUser();
        }
    }
}