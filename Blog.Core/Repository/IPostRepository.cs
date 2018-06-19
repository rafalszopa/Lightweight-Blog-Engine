using Blog.Core.Models;
using System.Collections.Generic;

namespace Blog.Core.Repository
{
    public interface IPostRepository
    {
        int AddPost(Post entity);

        int AddPostDetails(int postId, PostDetails entity);

        Post GetById(int id);

        void Delete(int id);

        void Update(Post entity);

        Post GetFullPostById(int id);

        IEnumerable<Post> GetAll();
    }
}
