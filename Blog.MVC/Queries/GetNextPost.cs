using Blog.MVC.ViewModels;
using System;
using System.Data;

namespace Blog.MVC.Queries
{
    public class GetNextPost : IQuery<HomePageViewModel>
    {
        private int currentPostId;

        public GetNextPost(int currentPostId)
        {
            this.currentPostId = currentPostId;
        }

        public HomePageViewModel Execute(IDbConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
