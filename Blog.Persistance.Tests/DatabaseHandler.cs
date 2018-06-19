using System.Data.SqlClient;
using System.IO;

namespace Blog.Persistance.Tests
{
    public static class DatabaseHandler
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-NA9A7AC;Initial Catalog=Blog.IntegrationTests;User id=DESKTOP-NA9A7AC\Rafal;Integrated Security=True;";

        public static void ExecuteSqlScript(string scriptToExecute)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(scriptToExecute, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void ClearDatabase()
        {
            var scriptsToExecute = new string[]
            {
                File.ReadAllText(@"E:\Projects\lightweight-blog-engine\Blog.Persistance.Tests\SqlScripts\ClearTestDatabase.sql"),
                File.ReadAllText(@"E:\Projects\lightweight-blog-engine\Blog.Persistance.Tests\SqlScripts\TriggerInserfPost_Tag.sql"),
                File.ReadAllText(@"E:\Projects\lightweight-blog-engine\Blog.Persistance.Tests\SqlScripts\TriggerDeletePost_Tag.sql")
            };

            foreach(var script in scriptsToExecute)
            {
                ExecuteSqlScript(script);
            }
        }
    }
}
