using System.Collections.Generic;

namespace Blog.Core.Repository.Filters
{
    public static class IntegerColumnExtensions
    {
        public static void EqualTo(this IntegerColumn integerColumn, int value)
        {
            integerColumn.Value = value;
            integerColumn.Operator = IntegerColumn.Operators.EqualTo;
        }

        public static void NotEqualTo(this IntegerColumn integerColumn, int value)
        {
            integerColumn.Value = value;
            integerColumn.Operator = IntegerColumn.Operators.NotEqualTo;
        }

        public static void GreaterThan(this IntegerColumn integerColumn, int value)
        {
            integerColumn.Value = value;
            integerColumn.Operator = IntegerColumn.Operators.GreaterThan;
        }

        public static void LessThen(this IntegerColumn integerColumn, int value)
        {
            integerColumn.Value = value;
            integerColumn.Operator = IntegerColumn.Operators.LessThan;
        }

        public static void GreaterThanOrEqualTo(this IntegerColumn integerColumn, int value)
        {
            integerColumn.Value = value;
            integerColumn.Operator = IntegerColumn.Operators.GreaterThanOrEqualTo;
        }

        public static void LessThanOrEqualTo(this IntegerColumn integerColumn, int value)
        {
            integerColumn.Value = value;
            integerColumn.Operator = IntegerColumn.Operators.LessThanOrEqualTo;
        }

        public static void In(this IntegerColumn integerColumn, IEnumerable<int> values)
        {
            integerColumn.Range = values;
            integerColumn.Operator = IntegerColumn.Operators.In;
        }
    }
}
