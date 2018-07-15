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
        public IActionResult Post(string slug)
        {
            return View("Post");
        }

        public IActionResult ListPosts()
        {
            return View("ListOfPosts");
        }
    }
}
