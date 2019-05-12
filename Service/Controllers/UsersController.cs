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

        /*// GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }*/
        public ActionResult Create()
        {
            return View();
        }


        // POST: Users/Create
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

        /*// GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}