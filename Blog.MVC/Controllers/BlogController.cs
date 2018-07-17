using Blog.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class BlogController : Controller
    {
        // TO DO: Make interface for BlogService
        private readonly BlogService blogService;

        public BlogController(BlogService blogService = null)
        {
            this.blogService = blogService ?? new BlogService();
        }

        // GET: /<controller>/
        public IActionResult Post(string slug)
        {
            return View("Post");
        }

        public IActionResult ListPosts(int page)
        {
            var (posts, totalNumberOfPages) = this.blogService.GetListOfPosts(page);

            if (page > 1 && posts.Count == 0)
            {
                return RedirectToRoute("blog-list-all-posts", new { page = 1 });
            }

            ViewBag.CurrentPage = page;
            ViewBag.TotalNumberOfPages = totalNumberOfPages;

            return View("ListOfPosts", posts);
        }
    }
}
