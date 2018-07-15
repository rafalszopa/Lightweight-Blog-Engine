using System.Data;

namespace Blog.MVC.Queries
{
    public interface IQuery<T> where T : class
    {
        T Execute(IDbConnection connection);
    }
}
