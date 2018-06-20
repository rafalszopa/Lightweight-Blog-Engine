using Blog.Core.Models;

namespace Blog.Core.Repository
{
    public interface IPostTagsRepository
    {
        int Add(int postId, Tag tag);

        int Delete(int postId, Tag tag);
    }
}
