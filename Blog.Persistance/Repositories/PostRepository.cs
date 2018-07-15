using System;
using System.Collections.Generic;
using System.Data;
using Blog.Core.Models;
using Blog.Core.Repository;
using Blog.Core.Repository.Filters;
using Blog.Persistance.Queries;
using Dapper;

namespace Blog.Persistance.Repository
{
    public class PostRepository : IPostRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public PostRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public int Insert(Post entity)
        {
            throw new NotImplementedException();
        }

        public Post FindById(int postId)
        {
            var builder = new SqlBuilder();
            var selector = builder.AddTemplate(PostQuery.GetSinglePost());
            builder.Where("Id = @PostId");

            return this.connection.QueryFirstOrDefault<Post>(selector.RawSql, new { PostId = postId }, this.transaction);
        }

        public IEnumerable<Post> Find(int page, int size, PostFilter filter = null)
        {
            var builder = new SqlBuilder();
            var selector = builder.AddTemplate(PostQuery.GetManyPosts());
            
            if(filter != null)
            {
                builder.Where(SqlFilterGenerator.GenerateSql(filter));
            }

            return this.connection.Query<Post>(PostQuery.GetManyPosts(), new { PageIndex = page - 1, PageSize = size }, this.transaction);
        }

        public void Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> Foo()
        {
            string query = @"
                            SELECT
                            Posts.Id,
                            Posts.Title,
                            Posts.Description,
                            Posts.PhotoUrl,
                            Posts.PublishDate,
                            STUFF(
	                            (SELECT ',' + T.Name
	                            FROM Post_Tag PT
	                            LEFT JOIN Tags T ON PT.TagId = T.Id
	                            WHERE PT.PostId = Posts.Id
	                            FOR XML PATH('')),
	                            1, 1, '') _tags,
                            Users.FirstName Author_FirstName,
                            Users.LastName Author_LastName,
                            Users.Email Author_Email
                            FROM Posts
                            LEFT JOIN Users ON Posts.UserId = Users.Id
                            WHERE Posts.IsActive = 1;";

            var result = this.connection.Query<dynamic>(query, new { }, this.transaction);
            return result;
        }
    }
}
