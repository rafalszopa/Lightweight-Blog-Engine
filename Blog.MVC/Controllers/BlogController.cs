using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.MVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string slug)
        {
            var result = $"Post: {slug}";
            return Content(result);
            //return View();
        }

        public IActionResult Posts()
        {
            var result = $"List of all posts...";
            return Content(result);
            //return View();
        }
    }
}
