using BussinessLogic.Abstractions;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostLogic _postLogic;

        public HomeController(IPostLogic postLogic)
        {
            _postLogic = postLogic;
        }
        
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            var posts = _postLogic.GetAll();

            return View(posts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Post newPost)
        {
            if (ModelState.IsValid)
            {
                var post = new Entities.Entities.Post()
                {
                    Id = Guid.NewGuid(),
                    Title = newPost.Title,
                    Description = newPost.Description,
                    UserId = Guid.Parse("B5BB4833-CAB9-4F1C-9EB5-38910C958BEA")
                };

                _postLogic.Add(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newPost);
            }
        }

        public ActionResult Edit(Guid id)
        {
            var post = _postLogic.GetByFilter(p => p.Id == id);
            var postModel = new Models.Post()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description
            };
            return View(postModel);
        }

        [HttpPost]
        public ActionResult Edit(Models.Post updatedPost)
        {
            if (ModelState.IsValid)
            {
                var post = _postLogic.GetByFilter(p => p.Id == updatedPost.Id);
                post.Title = updatedPost.Title;
                post.Description = updatedPost.Description;

                _postLogic.Update(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(updatedPost);
            }
        }

        public ActionResult Details(Guid id)
        {
            var post = _postLogic.GetByFilter(p => p.Id == id);
            var postModel = new Models.Post()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description
            };
            return View(postModel);
        }

        public ActionResult Delete(Guid id)
        {
            var post = _postLogic.GetByFilter(p => p.Id == id);
            var postModel = new Models.Post()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description
            };
            return View(postModel);
        }

        [HttpPost]
        public ActionResult Delete(Models.Post postModel)
        {
            var post = _postLogic.GetByFilter(p => p.Id == postModel.Id);
            _postLogic.Delete(post);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    } 
}