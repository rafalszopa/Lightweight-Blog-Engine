using Blog.MVC.ViewModels;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Blog.MVC.Queries
{
    public class HomePagePostsQuery : IQuery<IEnumerable<PostTeaserViewModel>>
    {
        private readonly int pageIndex;

        private readonly int pageSize;

        public HomePagePostsQuery(int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        public IEnumerable<PostTeaserViewModel> Execute(IDbConnection connection)
        {
            var query =
                @"SELECT
                Posts.Slug,
                Posts.Title,
                Posts.Description,
                Posts.PhotoUrl,
                Posts.PublishDate,
                STUFF(
                    (SELECT ',' + T.Name
                    FROM Post_Tag PT
                    LEFT JOIN Tags T ON PT.TagId = T.Id
                    WHERE PT.PostId = Posts.Id
                    FOR XML PATH('')),
                    1, 1, '') _tags,
                Users.FirstName Author_FirstName,
                Users.LastName Author_LastName,
                Users.Email Author_Email
                FROM Posts
                LEFT JOIN Users ON Posts.UserId = Users.Id
                WHERE Posts.IsActive = 1
                ORDER BY PublishDate
                OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";

            var result = connection.Query<dynamic>(query, new { PageIndex = this.pageIndex, PageSize = this.pageSize });
            return Slapper.AutoMapper.MapDynamic<PostTeaserViewModel>(result);
        }
    }
}
