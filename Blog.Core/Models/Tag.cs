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

        public Tag(string name, int count = 0)
        {
            this.Name = name;
            this.Count = count;
        }
    }
}
