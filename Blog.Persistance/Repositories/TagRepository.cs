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
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                int affectedRows = connection.Execute(TagQuery.Add(), new { TagName = tag.Name });
                return affectedRows;
            }
        }

        public void AddMany(IEnumerable<Tag> tags)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                connection.Execute(TagQuery.AddMany(tags));
            }
        }

        public int DeleteByName(string tagName)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                int affectedRows = connection.ExecuteScalar<int>(TagQuery.Delete(), new { TagName = tagName });
                return affectedRows;
            }
        }

        public Tag GetByName(string tagName)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                var tag = connection.QueryFirstOrDefault<Tag>(TagQuery.GetTagByName(), new { TagName = tagName });
                return tag;
            }
        }

        public IEnumerable<Tag> GetTagsByPostId(int postId)
        {
            using(IDbConnection connection = ConnectionFactory.Get)
            {
                var tags = connection.Query<Tag>(TagQuery.GetTagsByPostId(), new { PostId = postId });
                return tags;
            }
        }

        public IEnumerable<Tag> GetAll()
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {               
                var tags = connection.Query<Tag>(TagQuery.GetAll()).ToList();
                return tags;
            }
        }
    }
}
