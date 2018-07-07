using Blog.Core.Models;

namespace Blog.Core.Repository
{
    public interface IPostTagsRepository
    {
        int Add(int postId, int tagId);

        int Delete(int postId, int tagId);
    }
}
