namespace Blog.Persistance.Queries
{
    internal static class PostTagsQuery
    {
        public static string Add()
        {
            return @"INSERT INTO Post_Tag(PostId, TagId) VALUES(@PostId, @TagId)";
        }

        public static string Delete()
        {
            return "DELETE FROM Post_Tag WHERE PostId = @PostId AND TagId = @TagId";
        }
    }
}
