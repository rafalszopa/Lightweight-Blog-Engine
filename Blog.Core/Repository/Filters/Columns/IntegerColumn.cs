using System.Collections.Generic;

namespace Blog.Core.Repository.Filters
{
    public class IntegerColumn : Column
    {
        public enum Operators
        {
            None = 0,
            EqualTo = 1,
            NotEqualTo = 2,
            GreaterThan = 3,
            LessThan = 4,
            GreaterThanOrEqualTo = 5,
            LessThanOrEqualTo = 6,
            In = 7,
        }

        public int Value { get; internal set; }

        public IEnumerable<int> Range { get; internal set; }

        public Operators Operator { get; internal set; }

        internal IntegerColumn(string columnName) : base(columnName)
        {
            this.Operator = Operators.None;
        }
    }
}
