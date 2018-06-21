using Blog.Core.Models;
using NUnit.Framework;
using System.Data;
using System.IO;
using System.Linq;
using Blog.Persistance.Repository;

namespace Blog.Persistance.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IDbTransaction transaction;

        private IDbConnection connection;

        private readonly UserRepository userRepository;

        private readonly string populateTestDataSqlScript;

        public UserRepositoryTests()
        {
            this.connection = ConnectionFactory.Get;
            this.transaction = this.connection.BeginTransaction();
            this.userRepository = new UserRepository(this.transaction);
            this.populateTestDataSqlScript = File.ReadAllText(@"E:\Projects\lightweight-blog-engine\Blog.Persistance.Tests\SqlScripts\UserRepositoryTestsData.sql");
        }

        [SetUp]
        public void Init()
        {
            DatabaseHandler.ClearDatabase();
            DatabaseHandler.ExecuteSqlScript(this.populateTestDataSqlScript);
        }

        [Test]
        public void AddAndGetById_ShouldPopulateNewUserInDatabaseAndThenReturnThatUser()
        {
            // Arrange
            var user = new User("Rafal", "Szopa", "rafalszopa.92@gmail.com", "Brief bio", UserType.Admin, true);

            // Act
            int id = this.userRepository.Add(user);
            var fetchedUser = this.userRepository.GetById(id);

            // Assert
            Assert.AreEqual(id, fetchedUser.Id);
            Assert.AreEqual(user.FirstName, fetchedUser.FirstName);
            Assert.AreEqual(user.LastName, fetchedUser.LastName);
            Assert.AreEqual(user.Email, fetchedUser.Email);
            Assert.AreEqual(user.Bio, fetchedUser.Bio);
            Assert.AreEqual(user.IsActive, fetchedUser.IsActive);
            Assert.AreEqual(user.Type, fetchedUser.Type);
        }

        [Test]
        public void Update_ShouldUpdateExistingUserInDatabase()
        {
            // Arrange
            var user = this.userRepository.GetById(1);
            user.FirstName = "updatedFirstName";
            user.LastName = "updatedLastName";
            user.Bio = "UpdatedBio";
            user.Email = "updated@email.com";
            user.Type = UserType.Author;
            user.IsActive = false;

            // Act
            int affectedRows = this.userRepository.Update(user);
            var updatedUser = this.userRepository.GetById(1);

            // Assert
            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual("updatedFirstName", updatedUser.FirstName);
            Assert.AreEqual("updatedLastName", updatedUser.LastName);
            Assert.AreEqual("UpdatedBio", updatedUser.Bio);
            Assert.AreEqual("updated@email.com", updatedUser.Email);
            Assert.AreEqual(UserType.Author, updatedUser.Type);
            Assert.AreEqual(false, updatedUser.IsActive);
        }

        [Test]
        public void GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            // Act
            var users = this.userRepository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, users.Count());
        }
    }
}
