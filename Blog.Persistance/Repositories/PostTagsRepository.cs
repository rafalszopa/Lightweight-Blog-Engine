using Blog.Core.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Blog.Persistance
{
    public class PostTagsRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public PostTagsRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public void Add(int postId, Tag tag)
        {
            this.connection.Execute(@"INSERT INTO Post_Tag(PostId, TagId) VALUES(@PostId, @TagId)", new { PostId = postId, TagId = tag.Id }, this.transaction);
        }

        public void AddTags(int postId, IEnumerable<Tag> tags)
        {
            string query = @"INSERT INTO Post_Tag(PostId, TagId)";

            foreach(var tag in tags)
            {
                query = string.Format(@"VALUES({0}, {1});", postId, tag.Id);
            }
            query += ";";

            this.connection.Execute(query, this.transaction);
        }
    }
}
