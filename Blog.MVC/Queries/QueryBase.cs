namespace Blog.MVC.Queries
{
    public abstract class QueryBase
    {
        protected readonly IConnectionFactory connectionFactory;

        protected QueryBase(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}
