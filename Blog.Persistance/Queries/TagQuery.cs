using Blog.Core.Models;
using System.Collections.Generic;

namespace Blog.Persistance.Queries
{
    public static class TagQuery
    {
        public static string Add()
        {
            string query =
                @"IF NOT EXISTS(SELECT TOP 1 1 FROM Tags WHERE Name = @TagName)
                BEGIN
                    INSERT INTO Tags (Name, Count)
                    VALUES (@TagName, 0)
                    SELECT CAST(SCOPE_IDENTITY() as int)
                END
                ELSE
                BEGIN
                    SELECT -1
                END";

            return query;
        }

        public static string AddMany(IEnumerable<Tag> tags)
        {
            string query = string.Empty;

            foreach(var tag in tags)
            {
                query += string.Format(@"IF NOT EXISTS(SELECT 1 FROM Tags WHERE Name = {0})" +
                         "INSERT INTO Tags(Name, Count) VALUES ({0}, 0);", tag.Name);
            }

            return query;
        }

        public static string GetTagByName()
        {
            string query = 
                @"SELECT Id, Name, Count 
                FROM Tags 
                WHERE Name = @TagName;";

            return query;
        }

        public static string GetTagsByPostId()
        {
            string query =
                @"SELECT Tags.Name, Tags.Count
                FROM Post_Tag
                INNER JOIN Tags ON Post_Tag.Tag = Tags.Name
                WHERE PostId = @PostId;";

            return query;
        }

        public static string GetAll()
        {
            string query = 
                @"SELECT Name, Count
                FROM Tags;";

            return query;
        }

        public static string Delete()
        {
            string query =
                @"IF NOT EXISTS(SELECT 1 FROM Post_Tag WHERE Tag = @TagName)
                DELETE FROM Tags 
                WHERE Name = @TagName;
                SELECT @@ROWCOUNT;";

            return query;
        }
    }
}
