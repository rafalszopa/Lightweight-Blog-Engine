using System.Collections.Generic;
using Blog.Core.Repository;
using System.Data;
using Blog.Persistance.Queries;
using Dapper;
using System.Linq;
using Blog.Core.Models;

namespace Blog.Persistance
{
    public class TagRepository : ITagRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public TagRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public int Add(Tag tag)
        {
            int affectedRows = this.connection.Execute(TagQuery.Add(), new { TagName = tag.Name }, this.transaction);
            return affectedRows;
        }

        public void AddMany(IEnumerable<Tag> tags)
        {
            this.connection.Execute(TagQuery.AddMany(tags), this.transaction);
        }

        public int DeleteByName(string tagName)
        {
            int affectedRows = this.connection.ExecuteScalar<int>(TagQuery.Delete(), new { TagName = tagName }, this.transaction);
            return affectedRows;
        }

        public Tag GetByName(string tagName)
        {
            var tag = this.connection.QueryFirstOrDefault<Tag>(TagQuery.GetTagByName(), new { TagName = tagName }, this.transaction);
            return tag;
        }

        public IEnumerable<Tag> GetTagsByPostId(int postId)
        {
            var tags = this.connection.Query<Tag>(TagQuery.GetTagsByPostId(), new { PostId = postId }, this.transaction);
            return tags;
        }

        public IEnumerable<Tag> GetAll()
        {     
            var tags = this.connection.Query<Tag>(TagQuery.GetAll(), this.transaction).ToList();
            return tags;
        }
    }
}
