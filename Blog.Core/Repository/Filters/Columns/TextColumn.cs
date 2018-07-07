using System.Collections.Generic;

namespace Blog.Core.Repository.Filters
{
    public class TextColumn : Column
    {
        public enum Operators
        {
            None = 0,
            Like = 1,
            NotLike = 2,
            In = 3,
        }

        public string Value { get; internal set; }

        public IEnumerable<string> Range { get; internal set; }

        public Operators Operator { get; internal set; }

        internal TextColumn(string columnName) : base(columnName)
        {
            this.Operator = Operators.None;
        }
    }
}