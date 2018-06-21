using System;

namespace Blog.Core.Models
{
    public class Tag : ICloneable
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
            this.Id = id;
            this.name = name;
            this.Count = count;
        }

        public object Clone()
        {
            return new Tag(this.Id, this.Name, this.Count);
        }
    }
}
