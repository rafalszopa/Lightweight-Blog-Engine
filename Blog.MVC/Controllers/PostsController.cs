using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Models;
using Blog.MVC.Services;

namespace Blog.MVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly HomePageServices homePageService;

        public PostsController()
        {
            this.homePageService = new HomePageServices();
        }

        public IActionResult Index()
        {
            var posts = this.homePageService.Foo();

            return View(posts);
        }
    }
}
