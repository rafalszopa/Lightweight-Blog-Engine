using Blog.Core.Repository;
using System;
using Blog.Core.Models;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Blog.Persistance.Queries;
using System.Linq;

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

        public int AddPost(Post entity)
        {
            int postId = this.connection.ExecuteScalar<int>(
                PostQuery.AddPost(),
                new
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    CreateDate = entity.CreateDate,
                    PublishDate = entity.PublishDate,
                    PhotoUrl = entity.PhotoUrl,
                    UserId = entity.Author.Id,
                    Status = entity.Status
                },
                this.transaction);

            return postId;
        }

        public int AddPostDetails(int postId, PostDetails entity)
        {
            int affectedRows = this.connection.ExecuteScalar<int>(
                PostQuery.AddPostDetails(), new { PostId = postId, Content = entity.Content }, this.transaction);

            return affectedRows;
        }

        public Post GetFullPostById(int id)
        {
            Post fetchedPost = null;

            using (IDbConnection connection = ConnectionFactory.Get)
            {
                using (var result = connection.QueryMultiple(PostQuery.GetFullPost(), new { PostId = id }))
                {
                    var post = result.Read().FirstOrDefault();
                    var tags = result.Read<Tag>().ToList();
                    var postDetails = result.Read<PostDetails>().FirstOrDefault();
                    var author = result.Read<User>().FirstOrDefault();

                    fetchedPost = new Post(post.Title, post.Description, post.Status, post.CreateDate, post.PublishDate, post.PhotoUrl,
                        tags, postDetails, author, post.Id);
                }
            }

            return fetchedPost;
        }

        public void Update(Post entity)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                connection.Execute(PostQuery.Update() + PostQuery.UpdateTags(entity.Tags), 
                    new
                    {
                        PostId = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        PhotoUrl = entity.PhotoUrl,
                        Status = entity.Status,
                        Content = entity.Details.Content
                    });
            }
        }

        public Post GetById(int id)
        {
            string query =
                @"SELECT Id, Title, Description, CreateDate, PublishDate, PhotoUrl, StatusId FROM Posts WHERE Id = @PostId;";

            var post = this.connection.Query<Post>(query, new { @PostId = id }, this.transaction).FirstOrDefault();

            return post;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Foo(int i)
        {
            string sql = "SELECT * FROM Posts";

            using (IDbConnection connection = ConnectionFactory.Get)
            {
                var posts = connection.Query<Post>(sql);
            }
        }

        public IEnumerable<Post> GetAll()
        {
            var posts = this.connection.Query<Post>("SELECT * FROM Posts WHERE Id = @Id1 OR Id = @Id2;", new { Id1 = 1, Id2 = 2 }, this.transaction);
            return posts;
        }
    }
}
