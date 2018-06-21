using Blog.Core;
using System;
using System.Data;
using Blog.Core.Repository;
using System.Data.SqlClient;
using Blog.Persistance.Repository;

namespace Blog.Persistance
{
    /* TO DO:
     * RENAME CLASS (typo)!
     * pass connection string from constructor to ConnectionFactory
     * think about DI */
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        #region private fields

        private IDbConnection connection;

        private IDbTransaction transaction;

        private IPostRepository postRepository;

        private ITagRepository tagRepository;

        private IUserRepository userRepository;

        private IPostTagsRepository postTagsRepository;

        private bool disposed;

        #endregion

        #region Constructor

        public UnityOfWork(string connection)
        {
            //this.connection = ConnectionFactory.Get;
            this.connection = new SqlConnection(@"Data Source=DESKTOP-NA9A7AC;Initial Catalog=Blog.IntegrationTests;User id=DESKTOP-NA9A7AC\Rafal;Integrated Security=True;");
            this.connection.Open();
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

        public IPostTagsRepository PostTagsRepository
        {
            get
            {
                return this.postTagsRepository ?? (this.postTagsRepository = new PostTagsRepository(this.transaction)); ;
            }
        }

        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
                throw;
            }
            finally
            {
                this.transaction.Dispose();
                this.transaction = connection.BeginTransaction();
                this.ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            this.postRepository = null;
            this.tagRepository = null;
            this.userRepository = null;
            this.postTagsRepository = null;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.transaction.Dispose();
                    this.transaction = null;
                }
                if (this.connection != null)
                {
                    this.connection.Dispose();
                    this.connection = null;
                }
            }

            this.disposed = true;
        }

        ~UnityOfWork()
        {
            this.Dispose(false);
        }
    }
}
