using Blog.MVC.DataAccess;
using Blog.MVC.Queries;
using Blog.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.MVC.Services
{
    public class BlogService
    {
        private readonly IConnectionFactory connectionFactory;

        public BlogService(IConnectionFactory connectionFactory = null)
        {
            this.connectionFactory = connectionFactory ?? new ConnectionFactory();
        }

        public (List<PostTeaserViewModel> posts, int totalNumberOfPages) GetListOfPosts(int page)
        {
            List<PostTeaserViewModel> posts;
            int totalNumberOfPages;

            using (var connection = connectionFactory.Create(AppSettings.ConnectionString))
            {
                posts = new HomePagePostsQuery(page - 1, AppSettings.NumberOfPostsPerPage).Execute(connection).ToList();
                var totalNumberOfPosts = new TotalNumberOfPostsQuery().Execute(connection);
                totalNumberOfPages = Decimal.ToInt32(Math.Ceiling((decimal)totalNumberOfPosts / AppSettings.NumberOfPostsPerPage));
            }

            return (posts, (totalNumberOfPages));
        }
    }
}
