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
    public class HomeController : Controller
    {
        private readonly IHomePageServices homePageService;

        public HomeController()
        {
            this.homePageService = new HomePageServices();
        }

        public IActionResult Index()
        {
            var posts = this.homePageService.GetPosts();

            return View(posts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
