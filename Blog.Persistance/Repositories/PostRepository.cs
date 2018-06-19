using Blog.Core.Repository;
using System;
using Blog.Core.Models;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Blog.Persistance.Queries;
using System.Data.SqlClient;
using System.Linq;

namespace Blog.Persistance
{
    public class PostRepository : IPostRepository
    {
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public PostRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public int Add(Post entity)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                int postId = 0;

                try
                {
                    // Add Post
                    postId = connection.ExecuteScalar<int>(PostQuery.Add(), new
                    {
                        Title = entity.Title,
                        Description = entity.Description,
                        CreateDate = entity.CreateDate,
                        PublishDate = entity.PublishDate,
                        PhotoUrl = entity.PhotoUrl,
                        UserId = entity.Author.Id,
                        Status = entity.Status
                    });

                    entity.Details.PostDetailsId = postId;

                    // Add Tags
                    var tagRepository = new TagRepository();
                    foreach(var tag in entity.Tags)
                    {
                        if (tagRepository.GetByName(tag.Name) == null)
                        {
                            tagRepository.Add(tag);
                        }

                        connection.Execute(PostTagQuery.Add(), new { PostID = postId, TagName = tag.Name });
                    }
                }
                catch (SqlException exception) when (exception.Number == 2627 || exception.Number == 2601)
                {
                    // Log information that value has already existed
                }

                return postId;
            }
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
            using (IDbConnection connection = ConnectionFactory.Get)
            {

            }

            return null;
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
            throw new NotImplementedException();
        }
    }
}
