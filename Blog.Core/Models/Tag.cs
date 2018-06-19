namespace Blog.Core.Models
{
    public class Tag
    {
        public string Name
        {
            get
            {
                return Name.ToLower();
            }
            private set { }
        }

        public int Count { get; private set; }

        public Tag() { }

        public Tag(string name) : this(name, 0) { }

        public Tag(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }
    }
}
