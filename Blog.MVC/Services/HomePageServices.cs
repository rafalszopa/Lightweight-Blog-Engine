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

        public IList<PostTeaserViewModel> GetHomePageViewModel()
        {
            List<PostTeaserViewModel> homePageViewModel;

            using (var connection = this.connectionFactory.Create(AppSettings.ConnectionString))
            {
                homePageViewModel = new HomePagePostsQuery(0, AppSettings.NumberOfHomePosts).Execute(connection);
            }

            return homePageViewModel;
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
