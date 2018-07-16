using Blog.MVC.ViewModels;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Blog.MVC.Queries
{
    public class GetHomaPageViewModel : IQuery<IEnumerable<HomePageViewModel>>
    {
        private readonly int pageIndex;

        private readonly int pageSize;

        public GetHomaPageViewModel(int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        public IEnumerable<HomePageViewModel> Execute(IDbConnection connection)
        {
            var query =
                @"SELECT * FROM HomePageView
                ORDER BY PublishDate
                OFFSET @PageIndex * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";

            var result = connection.Query<dynamic>(query, new { PageIndex = this.pageIndex, PageSize = this.pageSize });
            return Slapper.AutoMapper.MapDynamic<HomePageViewModel>(result);
        }
    }
}
