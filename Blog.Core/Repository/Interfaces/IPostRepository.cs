using System.Collections.Generic;
using Blog.Core.Models;
using Blog.Core.Repository.Filters;

namespace Blog.Core.Repository
{
    public interface IPostRepository
    {
        int Insert(Post entity);

        Post FindById(int postId);

        IEnumerable<Post> Find(PostFilter postFilter);
                
        void Delete(int postId);

        void Update(Post entity);
    }
}
