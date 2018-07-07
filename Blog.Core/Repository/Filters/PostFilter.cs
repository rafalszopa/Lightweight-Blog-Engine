namespace Blog.Core.Repository.Filters
{
    public class PostFilter
    {
        public IntegerColumn Id { get; private set; }

        public IntegerColumn AuthorId { get; private set; }

        public TextColumn Title { get; private set; }

        public IntegerColumn Status { get; private set; }

        public DateColumn CreatedOn { get; private set; }

        public DateColumn PublishedOn { get; private set; }

        public PostFilter()
        {
            Id = new IntegerColumn("Id");
            AuthorId = new IntegerColumn("AuthorId");
            Title = new TextColumn("Title");
            Status = new IntegerColumn("StatusId");
            CreatedOn = new DateColumn("CreateDate");
            PublishedOn = new DateColumn("PublishDate");
        }
    }
}
