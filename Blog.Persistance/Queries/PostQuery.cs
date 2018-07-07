using System.Collections.Generic;
using Blog.Core.Models;
using System.Text;
using Blog.Core.Repository.Filters;

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
                SELECT @@ROWCOUNT;";

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
                @"SELECT Content, Type
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
                JOIN Tags ON Post_Tag.TagId = Tags.Id
                WHERE Post_Tag.PostId = @PostId;";

            return query;
        }

        public static string Get()
        {
            string query = @"SELECT() FROM Posts";

            return query;
        }

        public static string GetFilters(PostFilter filter)
        {
            var query = new StringBuilder();

            query.Append("WHERE 1 = 1");

            if (filter.Id.Operator != IntegerColumn.Operators.None)
            {
                if (filter.Id.Operator == IntegerColumn.Operators.In)
                {
                    query.Append($" AND {filter.Id.Name} IN({string.Join(",", filter.Id.Range)})");
                }
                else
                {
                    query.Append($" AND {filter.Id.Name} {GetOperator(filter.Id.Operator)} {filter.Id.Value}");
                }
            }

            if (filter.AuthorId.Operator != IntegerColumn.Operators.None)
            {
                if (filter.AuthorId.Operator == IntegerColumn.Operators.In)
                {
                    query.Append($" AND {filter.AuthorId.Name} IN({string.Join(",", filter.AuthorId.Range)})");
                }
                else
                {
                    query.Append($" AND {filter.AuthorId.Name} {GetOperator(filter.AuthorId.Operator)} {filter.AuthorId.Value}");
                }
            }

            if (filter.Title != null)
            {
                if (filter.Title.Operator == TextColumn.Operators.In)
                {
                    query.Append($" AND Title IN('{string.Join(",", filter.Title.Range)}')");
                }
                else
                {
                    query.Append($" AND Title {GetOperator(filter.Title.Operator)} '{filter.Title.Value}'");
                }
            }

            if (filter.Status != null)
            {
                if (filter.Status.Operator == IntegerColumn.Operators.In)
                {
                    query.Append($" AND {filter.Status.Name} IN({string.Join(",", filter.Status.Range)})");
                }
                else
                {
                    query.Append($" AND {filter.Status.Name} {GetOperator(filter.Status.Operator)} {filter.Status.Value}");
                }
            }

            //if (filter.Status != null)
            //{
            //    if (filter.Status.Operator == IntegerColumn.Operators.In)
            //    {
            //        query.Append($" AND Status IN({string.Join(",", filter.Status.Range)})");
            //    }
            //    else
            //    {
            //        query.Append($" AND Status {GetOperator(filter.Status.Operator)} {filter.Status.Value}");
            //    }
            //}

            return query.ToString();
        }

        public static string GetOperator(IntegerColumn.Operators @operator)
        {
            var result = string.Empty;

            switch (@operator)
            {
                case IntegerColumn.Operators.EqualTo:
                    result = "=";
                    break;
                case IntegerColumn.Operators.GreaterThan:
                    result = ">";
                    break;
                case IntegerColumn.Operators.GreaterThanOrEqualTo:
                    result = ">=";
                    break;
                case IntegerColumn.Operators.In:
                    result = "IN";
                    break;
                case IntegerColumn.Operators.LessThanOrEqualTo:
                    result = "<=";
                    break;
                case IntegerColumn.Operators.LessThan:
                    result = "<";
                    break;
                case IntegerColumn.Operators.NotEqualTo:
                    result = "<>";
                    break;
            }

            return result;
        }

        public static string GetOperator(TextColumn.Operators @operator)
        {
            var result = string.Empty;

            switch (@operator)
            {
                case TextColumn.Operators.In:
                    result = "IN";
                    break;
                case TextColumn.Operators.Like:
                    result = "LIKE";
                    break;
                case TextColumn.Operators.NotLike:
                    result = "NOT LIKE";
                    break;
            }

            return result;
        }

        public static string GetOperator(DateColumn.Operators @operator)
        {
            var result = string.Empty;

            switch (@operator)
            {
                case DateColumn.Operators.In:
                    result = "IN";
                    break;
                case DateColumn.Operators.Between:
                    result = "BETWEEN";
                    break;
                case DateColumn.Operators.Like:
                    result = "LIKE";
                    break;
                case DateColumn.Operators.NotLike:
                    result = "NOT LIKE";
                    break;
            }

            return result;
        }
    }
}
