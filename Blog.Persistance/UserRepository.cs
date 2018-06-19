using Blog.Core.Models;
using Blog.Core.Repository;
using Blog.Persistance.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Blog.Persistance
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        public int Add(User entity)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                int affectedRows = connection.ExecuteScalar<int>(UserQuery.Add(),
                    new { FirstName = entity.FirstName, LastName = entity.LastName, Email = entity.Email,
                        Bio = entity.Bio, CreateDate = DateTime.Now, UserTypeId = entity.Type, IsActive = entity.IsActive });

                return affectedRows;
            }
        }

        public int Update(User entity)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                var affectedRows = connection.ExecuteScalar<int>(UserQuery.Update(),
                    new { @UserId = entity.Id, FirstName = entity.FirstName, LastName = entity.LastName, Email = entity.Email,
                        Bio = entity.Bio, UserType = entity.Type, IsActive = entity.IsActive });

                return affectedRows;
            }
        }

        public User GetById(int id)
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                var user = connection.Query<User>(UserQuery.GetById(), new { UserId = id }).FirstOrDefault();
                return user;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection connection = ConnectionFactory.Get)
            {
                var users = connection.Query<User>(UserQuery.GetAll());
                return users;
            }
        }
    }
}
