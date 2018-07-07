namespace Blog.Core.Repository.Filters
{
    public class UserFilter
    {
        public IntegerColumn Id { get; private set; }

        public TextColumn FirstName { get; private set; }

        public TextColumn LastName { get; private set; }

        public IntegerColumn Type { get; private set; }

        public DateColumn Create { get; private set; }

        public UserFilter()
        {
            this.Id = new IntegerColumn("Id");
            this.FirstName = new TextColumn("FirstName");
            this.LastName = new TextColumn("LastName");
            this.Type = new IntegerColumn("UserTypeId");
            this.Create = new DateColumn("CreateDate");
        }
    }
}
