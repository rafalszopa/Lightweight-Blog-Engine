using Blog.API.ViewModels;
using Blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController
    {
        private ICommandBus commandBus;

        private static IEnumerable<PostViewModel> Posts = new List<PostViewModel>()
        {
            new PostViewModel() { Id = 1, Title = "First post", CreatedOn = DateTime.Now.AddDays(-20).ToShortDateString() },
            new PostViewModel() { Id = 2, Title = "Another one", CreatedOn = DateTime.Now.AddDays(-23).ToShortDateString() },
            new PostViewModel() { Id = 3, Title = "Yet another", CreatedOn = DateTime.Now.AddDays(-43).ToShortDateString() },
            new PostViewModel() { Id = 4, Title = "And yet another", CreatedOn = DateTime.Now.AddDays(-2).ToShortDateString() },
            new PostViewModel() { Id = 5, Title = "This is the coolest one", CreatedOn = DateTime.Now.AddDays(-1).ToShortDateString() }
        };

        public PostsController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        [HttpGet("[action]")]
        public IEnumerable<PostViewModel> Index()
        {


            return Posts;
        }
    }
}
