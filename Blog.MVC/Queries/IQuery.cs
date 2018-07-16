using System.Data;

namespace Blog.MVC.Queries
{
    public interface IQuery<T>
    {
        T Execute(IDbConnection connection);
    }
}
