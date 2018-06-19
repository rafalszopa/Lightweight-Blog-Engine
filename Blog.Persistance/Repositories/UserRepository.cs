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
        private IDbTransaction transaction;

        private IDbConnection connection { get { return transaction.Connection; } }

        public UserRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        public int Add(User entity)
        {
            int affectedRows = this.connection.ExecuteScalar<int>(
                UserQuery.Add(),
                new
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Bio = entity.Bio,
                    CreateDate = DateTime.Now,
                    UserTypeId = entity.Type,
                    IsActive = entity.IsActive
                },
                this.transaction);

                return affectedRows;
        }

        public int Update(User entity)
        {
            var affectedRows = this.connection.ExecuteScalar<int>(
                UserQuery.Update(),
                new
                {
                    UserId = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Bio = entity.Bio,
                    UserType = entity.Type,
                    IsActive = entity.IsActive
                },
                this.transaction);

            return affectedRows;
        }

        public User GetById(int id)
        {
            var user = this.connection.Query<User>(UserQuery.GetById(), new { UserId = id }, this.transaction).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = this.connection.Query<User>(UserQuery.GetAll(), this.transaction);
            return users;
        }
    }
}
