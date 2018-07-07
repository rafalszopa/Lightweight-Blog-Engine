using System.Collections.Generic;

namespace Blog.Core.Repository.Filters
{
    public static class TextColumnExtensions
    {
        public static void Like(this TextColumn textColumn, string value)
        {
            textColumn.Value = value;
            textColumn.Operator = TextColumn.Operators.Like;
        }

        public static void NotLike(this TextColumn textColumn, string value)
        {
            textColumn.Value = value;
            textColumn.Operator = TextColumn.Operators.NotLike;
        }

        public static void In(this TextColumn textColumn, IEnumerable<string> range)
        {
            textColumn.Range = range;
            textColumn.Operator = TextColumn.Operators.In;
        }
    }
}
