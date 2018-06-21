using Blog.Core.Models;
using Blog.Core.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Blog.Persistance.Repository;

namespace Blog.Persistance.Tests
{
    [TestFixture]
    public class TagRepositoryTests
    {
        private IDbTransaction transaction;

        private IDbConnection connection;

        private readonly ITagRepository tagRepository;

        private readonly string populateTestDataSqlScript;

        public TagRepositoryTests()
        {
            this.connection = ConnectionFactory.Get;
            this.transaction = this.connection.BeginTransaction();

            this.tagRepository = new TagRepository(this.transaction);
            this.populateTestDataSqlScript = File.ReadAllText(@"E:\Projects\lightweight-blog-engine\Blog.Persistance.Tests\SqlScripts\TagRepositoryTestsData.sql");
        }

        [SetUp]
        public void Init()
        {
            DatabaseHandler.ClearDatabase();
            DatabaseHandler.ExecuteSqlScript(this.populateTestDataSqlScript);
        }

        [Test]
        public void Add_ShouldPopulateNewTagInDatabaseAndReturnNumberOfAffectedRows()
        {
            // Arrange
            var tag = new Tag("newTag");

            // Act
            int affectedRows = this.tagRepository.Add(tag);
            var populatedTag = this.tagRepository.GetByName("newTag");

            // Assert
            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual("newTag", populatedTag.Name);
            Assert.AreEqual(0, populatedTag.Count);
        }

        [Test]
        public void Add_InsertTheSameTagTwice_OnlyOneTagShoulExistInDatabase()
        {
            // Arrange
            var tag = new Tag("newTag");

            // Act
            int affectedRowsFirstInsert = this.tagRepository.Add(tag);
            int affectedRowsSecondInsert = this.tagRepository.Add(tag);
            var populatedTag = this.tagRepository.GetByName("newTag");

            // Assert
            Assert.AreEqual(1, affectedRowsFirstInsert);
            Assert.AreEqual(0, affectedRowsSecondInsert);
            Assert.AreEqual("newTag", populatedTag.Name);
            Assert.AreEqual(0, populatedTag.Count);
        }

        [Test]
        public void AddMany_ShouldPopulateManyTags()
        {
            // Arrange
            // Act
            var newTags = new List<Tag>()
            {
                new Tag("newTag1"),
                new Tag("newTag2")
            };
            this.tagRepository.AddMany(newTags);
            var allTags = this.tagRepository.GetAll().ToList();

            // Assert
            Assert.AreEqual(4, allTags.Count());
            Assert.AreEqual("tag1", allTags[0].Name);
            Assert.AreEqual("tag2", allTags[1].Name);
            Assert.AreEqual("newTag1", allTags[2].Name);
            Assert.AreEqual("newTag2", allTags[3].Name);
        }

        [Test]
        public void Delete_TagExists_ShouldDeleteTagAndReturnOne()
        {
            // Arrange
            // Act
            int affectedRows = this.tagRepository.DeleteByName("tag3");

            // Assert
            Assert.AreEqual(1, affectedRows);
        }

        [Test]
        public void Delete_TagDoesNotExist_ShouldReturnZero()
        {
            // Arrange
            // Act
            int affectedRows = this.tagRepository.DeleteByName("wrongTag");

            // Assert
            Assert.AreEqual(0, affectedRows);
        }

        [Test]
        public void Delete_TagIsReferencedInPost_TagTable_ShouldNotDeleteTagAndReturnZero()
        {
            // Arrange
            // Act
            int affectedRows = this.tagRepository.DeleteByName("tag1");

            // Assert
            Assert.AreEqual(0, affectedRows);
        }

        [Test]
        public void GetByName_TagExists_ShouldReturnProperTag()
        {
            // Arrange
            // Act
            var tag = this.tagRepository.GetByName("tag2");

            // Assert
            Assert.AreEqual("tag2", tag.Name);
            Assert.AreEqual(2, tag.Count);
        }

        [Test]
        public void GetByName_TagDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            // Act
            var tag = this.tagRepository.GetByName("wrongTag");

            // Assert
            Assert.AreEqual(null, tag);
        }

        [Test]
        public void GetTagsByPostId_PostExists_ShouldReturnAllPostsTags()
        {
            // Arrange
            // Act
            var tags = this.tagRepository.GetTagsByPostId(1).ToList();

            // Assert
            Assert.AreEqual(2, tags.Count());
            Assert.AreEqual("tag1", tags[0].Name);
            Assert.AreEqual("tag2", tags[0].Name);
        }

        [Test]
        public void GetTagsByPostId_PostDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            // Act
            var tags = this.tagRepository.GetTagsByPostId(2).ToList();

            // Assert
            Assert.AreEqual(0, tags.Count());
        }

        [Test]
        public void GetAll_ShouldReturnAllTags()
        {
            // Arrange
            // Act
            var tags = this.tagRepository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, tags.Count());
            Assert.AreEqual("tag1", tags[0].Name);
            Assert.AreEqual(1, tags[0].Count);
            Assert.AreEqual("tag2", tags[1].Name);
            Assert.AreEqual(2, tags[1].Count);
        }
    }
}
