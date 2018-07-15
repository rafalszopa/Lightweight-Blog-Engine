using Blog.Core.Models;
using Blog.MVC.Queries;
using Blog.MVC.ViewModels;
using Blog.Persistance;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Blog.MVC.Services
{
    public class HomePageServices : IHomePageServices
    {
        public HomePageServices()
        {
            /*his.unitOfWork = new UnityOfWork("connectionString");*/
        }

        public IList<HomePageViewModel> GetHomePageViewModel()
        {
            IDbConnection connection = new SqlConnection(AppSettings.ConnectionString);
            var homePageViewModel = new GetHomaPageViewModel().Execute(connection);

            return homePageViewModel.ToList();
        }

        public Post Foo()
        {
            using (var unitOfWork = new UnityOfWork("connectionString"))
            {
                var post = unitOfWork.PostRepository.FindById(1);
                post.Tags = unitOfWork.TagRepository.GetTagsByPostId(1).ToList();
                post.Details = unitOfWork.PostDetailsRepository.GetById(1);

                return post;
            }
        }
    }

    public static class AppSettings
    {
        public static int NumberOfHomePosts = 5;

        public static string ConnectionString
        {
            get
            {
                return @"Data Source=DESKTOP-NA9A7AC;Initial Catalog=Blog.IntegrationTests;User id=DESKTOP-NA9A7AC\Rafal;Integrated Security=True;";
            }
        }
    }

    public static class HomePageSettings
    {
        public static int PageSize
        {
            get
            {
                return 5;
            }
        }
    }

}
