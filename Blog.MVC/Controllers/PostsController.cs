using Microsoft.AspNetCore.Mvc;
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
            var (posts, totalNumberOfPosts) = this.homePageService.GetHomePageViewModel();
            ViewBag["TotalNumberOfPosts"] = totalNumberOfPosts;

            return View(posts);
        }
    }
}
