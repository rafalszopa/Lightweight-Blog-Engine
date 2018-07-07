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
            throw new NotImplementedException();
        }

        public IEnumerable<Post> Find(PostFilter filter = null)
        {
            //var query = PostQuery.GetFilters(filter);

            string where = string.Empty;

            SqlFilterGenerator.GenerateSql(filter, ref where);

            // If filter != null
            // GetQuery 

            throw new NotImplementedException();
        }

        public void Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
