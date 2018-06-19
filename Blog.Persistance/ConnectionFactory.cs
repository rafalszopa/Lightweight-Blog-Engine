using System.Data;
using System.Data.SqlClient;

namespace Blog.Persistance
{
    public static class ConnectionFactory
    {
        // TO DO: Move Connection String to configuration file
        private static string connectionString = @"Data Source=DESKTOP-NA9A7AC;Initial Catalog=Blog.IntegrationTests;User id=DESKTOP-NA9A7AC\Rafal;Integrated Security=True;";

        public static IDbConnection Get
        {
            get
            {
                IDbConnection connection = new SqlConnection(connectionString);
                connection.Open();

                return connection;
            }
        }

    }
}
