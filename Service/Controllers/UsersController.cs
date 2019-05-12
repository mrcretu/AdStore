using BussinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Service.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserLogic _userLogic;

        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: Users
        public IActionResult Index()
        {
            var users = _userLogic.GetAll();

            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User newUser)
        {

            if (ModelState.IsValid)
            {
                var user = new Entities.Entities.User()
                {
                    Username = newUser.Username,
                    Password = newUser.Password,
                    Role = 0
                };

                _userLogic.Add(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newUser);
            }
        }
    }
}