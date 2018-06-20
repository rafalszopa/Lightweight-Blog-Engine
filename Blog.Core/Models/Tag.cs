namespace Blog.Core.Models
{
    public class Tag
    {
        public int Id { get; private set; }

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

        public Tag(string name) : this(0, name) { }

        public Tag(int id, string name, int count = 0)
        {
            this.name = name;
            this.Count = count;
        }
    }
}
