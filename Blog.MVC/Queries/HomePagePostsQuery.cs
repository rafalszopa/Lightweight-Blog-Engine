using Blog.MVC.ViewModels;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;

namespace Blog.MVC.Queries
{
    public class HomePagePostsQuery : IQuery<List<PostTeaserViewModel>>
    {
        private readonly int pageIndex;

        private readonly int pageSize;

        public HomePagePostsQuery(int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        public List<PostTeaserViewModel> Execute(IDbConnection connection)
        {

            // TO DO: Moved it to database as a View
            var query =
                @"SELECT
                Posts.Slug,
                Posts.Title,
                Posts.Description,
                Posts.PhotoUrl,
                Posts.PublishDate PublishedOn,
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
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var result = connection.Query<dynamic>(query, new { Offset = this.pageIndex * this.pageSize, PageSize = this.pageSize }).ToList();
            var mid = Slapper.AutoMapper.MapDynamic<PostTeaserViewModel>(result, false);
            var list = mid.ToList();
            return list;
        }
    }
}
