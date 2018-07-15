using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Post(string slug)
        {
            return View("Post");
        }

        public IActionResult ListPosts(int page)
        {
            return View("ListOfPosts");
        }
    }
}
