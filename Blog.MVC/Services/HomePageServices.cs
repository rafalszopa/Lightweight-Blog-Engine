using System.Collections.Generic;
using System.Linq;
using Blog.MVC.DataAccess;
using Blog.MVC.Queries;
using Blog.MVC.ViewModels;

namespace Blog.MVC.Services
{
    // Rename to BlogServices
    public class HomePageServices : IHomePageServices
    {
        private readonly IConnectionFactory connectionFactory;

        public HomePageServices(IConnectionFactory connectionFactory = null)
        {
            this.connectionFactory = connectionFactory ?? new ConnectionFactory();
        }

        public (IList<PostTeaserViewModel> posts, int totalNumberOfPosts) GetHomePageViewModel()
        {
            using (var connection = this.connectionFactory.Create(AppSettings.ConnectionString))
            {
                var homePageViewModel = new HomePagePostsQuery(0, 5).Execute(connection);
                var numberOfPosts = new TotalNumberOfPostsQuery().Execute(connection);

                return (posts: homePageViewModel.ToList(), totalNumberOfPosts: numberOfPosts);
            }
        }

        public (IList<PostTeaserViewModel> posts, int totalNumberOfPosts) GetListOfPosts(int page)
        {
            var connection = this.connectionFactory.Create(AppSettings.ConnectionString);
            var homePageViewModel = new HomePagePostsQuery(page - 1, 5).Execute(connection);

            return (posts: homePageViewModel.ToList(), totalNumberOfPosts: 17);
        }

        // TO DO: Implement following methods: GetHomePagePosts, GetListOfPosts, GetPage, Tags (!), SearchByTag(string[] tags)
    }
}
