using System.Data;
using System.Data.SqlClient;

namespace Blog.MVC.DataAccess
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
