using Blog.MVC.ViewModels;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Blog.MVC.Queries
{
    public class GetHomaPageViewModel : IQuery<IEnumerable<HomePageViewModel>>
    {
        public IEnumerable<HomePageViewModel> Execute(IDbConnection connection)
        {
            var query =
                @"SELECT * FROM HomePageView
                ORDER BY PublishDate
                OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";

            var result = connection.Query<dynamic>(query, new { PageIndex = 0, PageSize = 5 });
            return Slapper.AutoMapper.MapDynamic<HomePageViewModel>(result);
        }
    }
}
