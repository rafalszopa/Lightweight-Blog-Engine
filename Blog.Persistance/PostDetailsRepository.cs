using Blog.Core.Models;
using Blog.Persistance.Queries;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Blog.Persistance
{
    public class PostDetailsRepository
    {
        public PostDetailsRepository()
        {

        }

        public int Add(PostDetails entity)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                int postDetailsId = 0;

                try
                {
                    //postDetailsId = connection.ExecuteScalar<int>(PostDetailsQuery.Add(), new
                    //{
                    //    PostId = entity.PostDetailsId,
                    //    Content = entity.Content
                    //});
                }
                catch (SqlException exception) when (exception.Number == 2627 || SqlExceptions.CannotInsertDuplicateValue.CompareTo(exception.Number) == 0)
                {
                    // Log information that value has already existed
                }

                return postDetailsId;
            }
        }
    }
}
