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
        public ActionResult Create([Bind("Title","Description")]Post postModel)
        {
            var post = _postLogic.Add(new Post
            {
                Id = Guid.NewGuid(),
                Title = postModel.Title,
                Description = postModel.Description,
                UserId = Guid.Parse("9C88ED87-4710-49F6-AA25-1CCEF965D5E7")
            });
            return View(post);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind("Title", "Description")]Post postModel)
        {
            var post = _postLogic.GetByFilter(p => p.Id == postModel.Id);
            _postLogic.Update(post);
            return View(post);
        }

        public ActionResult About()
        {
            return View();
        }
    } 
}