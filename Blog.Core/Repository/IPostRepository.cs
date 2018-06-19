using Blog.Core.Models;
using System.Collections.Generic;

namespace Blog.Core.Repository
{
    public interface IPostRepository
    {
        int Add(Post entity);

        Post GetById(int id);

        void Delete(int id);

        void Update(Post entity);

        Post GetFullPostById(int id);

        IEnumerable<Post> GetAll();
    }
}
