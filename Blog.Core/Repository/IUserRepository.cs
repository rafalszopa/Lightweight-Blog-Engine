using Blog.Core.Models;
using System.Collections.Generic;

namespace Blog.Core.Repository
{
    public interface IUserRepository
    {
        int Add(User entity);

        int Update(User entity);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}
