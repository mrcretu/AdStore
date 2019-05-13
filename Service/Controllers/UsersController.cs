using System;
using System.Linq;
using BussinessLogic.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Service.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IPostLogic _postLogic;

        public UsersController(IUserLogic userLogic, IPostLogic postLogic)
        {
            _userLogic = userLogic;
            _postLogic = postLogic;
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

        public ActionResult Edit(Guid id)
        {
            var user = _userLogic.GetByFilter(u => u.Id == id);
            var userModel = new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Edit(Models.User updatedUser)
        {
            if (ModelState.IsValid)
            {
                var user = _userLogic.GetByFilter(u => u.Id == updatedUser.Id);
                user.Username = updatedUser.Username;
                user.Password = updatedUser.Password;

                _userLogic.Update(user);
                return RedirectToAction("Index");

            }
            else
            {
                return View(updatedUser);
            }
        }

        public ActionResult Details(Guid id)
        {
            var user = _userLogic.GetByFilter(u => u.Id == id);
            var userModel = new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
            return View(userModel);
        }

        public ActionResult Delete(Guid id)
        {
            var user = _userLogic.GetByFilter(u => u.Id == id);
            var userModel = new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Delete(Models.User userModel)
        {
            var user = _userLogic.GetByFilter(u => u.Id == userModel.Id);
            var userPosts = _postLogic.GetAll().Where(p => p.UserId == user.Id);
            foreach (var post in userPosts)
            {
                _postLogic.Delete(post);
            }
            _userLogic.Delete(user);
            return RedirectToAction("Index");
        }
    }
}