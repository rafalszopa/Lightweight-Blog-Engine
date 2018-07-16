using Dapper;
using System.Data;
using System.Linq;

namespace Blog.MVC.Queries
{
    public class TotalNumberOfPostsQuery : IQuery<int>
    {
        public int Execute(IDbConnection connection)
        {
            return connection.Query<int>(@"SELECT Count(Id) FROM Posts WHERE IsActive = 1;").First();
        }
    }
}
