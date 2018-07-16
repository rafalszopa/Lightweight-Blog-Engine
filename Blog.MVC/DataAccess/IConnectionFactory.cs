using System.Data;

namespace Blog.MVC.DataAccess
{
    public interface IConnectionFactory
    {
        IDbConnection Create(string coonnectionString);
    }
}
