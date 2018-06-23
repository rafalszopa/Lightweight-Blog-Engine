using Blog.Core.Models;

namespace Blog.Core.Repository
{
    public interface IPostDetailsRepository
    {
        PostDetails GetById(int postId);
    }
}
