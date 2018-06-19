using Blog.Core;
using System;
using System.Data;
using Blog.Core.Repository;

namespace Blog.Persistance
{
    /* TO DO:
     - pass connection string from constructor to ConnectionFactory
     - think about DI */
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        #region private fields

        private IDbConnection connection;

        private IDbTransaction transaction;

        private IPostRepository postRepository;

        private ITagRepository tagRepository;

        private IUserRepository userRepository;

        #endregion

        #region Constructor

        public UnityOfWork(string connection)
        {
            this.connection = ConnectionFactory.Get;
            this.transaction = this.connection.BeginTransaction();
        }

        #endregion

        public IPostRepository PostRepository
        {
            get
            {
                return this.postRepository ?? (this.postRepository = new PostRepository(this.transaction));
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                return this.tagRepository ?? (this.tagRepository = new TagRepository(this.transaction)); ;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository ?? (this.userRepository = new UserRepository(this.transaction)); ;
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
