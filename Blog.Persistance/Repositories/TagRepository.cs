using System.Collections.Generic;
using Blog.Core.Repository;
using System.Data;
using Blog.Persistance.Queries;
using Dapper;
using System.Linq;
using Blog.Core.Models;

// TO DO: fix namespace
namespace Blog.Persistance.Repository
{
    public class TagRepository : ITagRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public TagRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        // Returns id of inserted record or -1 if record already exists
        public int Add(Tag tag)
        {
            int tagId = this.connection.ExecuteScalar<int>(TagQuery.Add(), new { TagName = tag.Name }, this.transaction);
            return tagId;
        }

        public void AddMany(IEnumerable<Tag> tags)
        {
            foreach(var tag in tags)
            {
                this.Add(tag);
            }
            //this.connection.Execute(TagQuery.AddMany(tags), this.transaction);
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
