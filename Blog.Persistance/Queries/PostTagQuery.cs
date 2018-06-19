namespace Blog.Persistance.Queries
{
    internal static class PostTagQuery
    {
        public static string Add()
        {
            return "INSERT INTO Post_Tag(PostId, Tag) VALUES(@PostId, @TagName)";
        }

        public static string Delete()
        {
            return "DELETE FROM Post_Tag WHERE PostId = @PostId AND Tag = @TagName";
        }
    }
}
