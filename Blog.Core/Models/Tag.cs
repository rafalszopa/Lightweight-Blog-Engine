namespace Blog.Core.Models
{
    public class Tag
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name.ToLower();
            }
        }

        public int Count { get; private set; }

        public Tag() { }

        public Tag(string name) : this(name, 0) { }

        public Tag(string name, int count)
        {
            this.name = name;
            this.Count = count;
        }
    }
}
