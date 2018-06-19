using Blog.Core.Repository;

namespace Blog.Core
{
    public interface IUnityOfWork
    {
        IPostRepository PostRepository { get; }

        ITagRepository TagRepository { get; }

        IUserRepository UserRepository { get; }

        void Commit();
    }
}
