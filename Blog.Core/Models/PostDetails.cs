namespace Blog.Core.Models
{
    public class PostDetails
    {
        //public int PostDetailsId { get; private set; }

        public string Content { get; set; }

        public ContentType Type { get; set; }

        public PostDetails() { }
    }
}
