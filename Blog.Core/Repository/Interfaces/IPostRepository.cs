using System.Collections.Generic;
using Blog.Core.Models;
using Blog.Core.Repository.Filters;

namespace Blog.Core.Repository
{
    public interface IPostRepository
    {
        int insertAddPost(Post entity);

        Post FindById(int postId);

        IEnumerable<Post> Find(PostFilter postFilter, int? take = null, int? skip = null);
                
        void Delete(int postId);

        void Update(Post entity);
    }
}
