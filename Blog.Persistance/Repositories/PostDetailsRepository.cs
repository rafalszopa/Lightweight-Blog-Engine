using Blog.Core.Models;
using Blog.Core.Repository;
using Dapper;
using System.Data;
using System.Linq;

namespace Blog.Persistance.Repositories
{
    public class PostDetailsRepository : IPostDetailsRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public PostDetailsRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public PostDetails GetById(int postId)
        {
            string query = @"SELECT Content, Type FROM PostDetails WHERE PostId = @PostId;";
            var postDetails = this.connection.Query<PostDetails>(query, new { PostId = postId }, this.transaction).FirstOrDefault();
            return postDetails;
        }
    }
}
