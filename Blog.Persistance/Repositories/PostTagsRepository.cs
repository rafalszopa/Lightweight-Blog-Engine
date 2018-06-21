using System.Data;
using Blog.Core.Models;
using Blog.Core.Repository;
using Blog.Persistance.Queries;
using Dapper;

namespace Blog.Persistance.Repository
{
    public class PostTagsRepository : IPostTagsRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public PostTagsRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public int Add(int postId, int tagId)
        {
            var affectedRows = this.connection.ExecuteScalar<int>(PostTagsQuery.Add(), new { PostId = postId, TagId = tagId }, this.transaction);
            return affectedRows;
        }

        public int Delete(int postId, int tagId)
        {
            var affectedRows = this.connection.ExecuteScalar<int>(PostTagsQuery.Delete(), new { PostId = postId, TagId = tagId }, this.transaction);
            return affectedRows;
        }
    }
}
