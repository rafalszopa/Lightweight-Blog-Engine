using Blog.MVC.ViewModels;
using System;
using System.Data;

namespace Blog.MVC.Queries
{
    public class NextPostQuery : IQuery<PostTeaserViewModel>
    {
        private int currentPostId;

        public NextPostQuery(int currentPostId)
        {
            this.currentPostId = currentPostId;
        }

        public PostTeaserViewModel Execute(IDbConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
