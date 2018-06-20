using System.Collections.Generic;
using Blog.Core.Models;

namespace Blog.Persistance.Queries
{
    public static class PostQuery
    {
        public static string GetFullPost()
        {
            return GetPost() + GetPostTags() + GetPostDetails() + GetPostDetails();
        }

        public static string AddPost()
        {
            string query = 
                @"INSERT INTO Posts (Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId)
                VALUES (@Title, @Description, @CreateDate, @PublishDate, @PhotoUrl, @UserId, @Status)
                SELECT CAST(SCOPE_IDENTITY() as int);";

            return query;
        }

        public static string AddPostDetails()
        {
            string query =
                @"INSERT INTO PostDetails (PostId, Content)
                VALUES (@PostId, @Content);
                SELECT @@ROWCOUNT;;";

            return query;
        }

        public static string GetPost()
        {
            string query =
                @"SELECT Posts.Id, Posts.Title, Posts.Description, Posts.CreateDate, Posts.PublishDate, Posts.PhotoUrl, PostStatuses.Status
                FROM Posts
                JOIN PostStatuses ON Posts.StatusId = PostStatuses.PostStatusId
                WHERE Id = @PostId;";

            return query;
        }

        public static string Update()
        {
            string query =
                @"UPDATE Posts
                SET Title = @Title, Description = @Description, CreateDate = @CreateDate, PublishDate = @PublishDate, PhotoUrl = @PhotoUrl, UserId = @UserId, StatusId = @Status
                WHERE Id = @PostId;
                UPDATE PostDetails
                SET Content = @Content
                WHERE PostId = @PostId;";

            return query;
        }
        
        public static string GetPostDetails()
        {
            string query =
                @"SELECT Content
                FROM PostDetails
                WHERE PostId = @PostId;";

            return query;
        }

        public static string UpdateTags(IEnumerable<Tag> tags)
        {
            string query = 
                @"DELETE FROM Post_Tag
                WHERE PostId = @PostId;";

            foreach(var tag in tags)
            {
                query += string.Format("IF NOT EXISTS(SELECT 1 FROM Tags WHERE Name = {0}) INSERT INTO Tags(Name, Count) VALUES ({0}, 0);", tag.Name);
                query += string.Format("INSERT INTO Post_Tag(PostId, Tag) VALUES(@PostId, {0});", tag.Name);
            }

            return query;
        }

        public static string GetPostTags()
        {
            string query = 
                @"SELECT Tags.Name, Tags.Count
                FROM Post_Tag
                JOIN Tags ON Post_Tag.Tag = Tags.Name
                WHERE Post_Tag.PostId = @PostId;";

            return query;
        }

        public static string Get()
        {
            string query = @"SELECT() FROM Posts";

            return query;
        }
    }
}
