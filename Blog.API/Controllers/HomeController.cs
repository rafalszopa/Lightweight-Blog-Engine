using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Services;

namespace lightweight_blog_engine.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomePageServices homePageServices;

        // TO DO: Dependency Injection
        public HomeController(HomePageServices homePageServices)
        {
            this.homePageServices = homePageServices;
        }

        public IActionResult Index()
        {
            var viewModel = this.homePageServices.GetHomePageViewModel();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
