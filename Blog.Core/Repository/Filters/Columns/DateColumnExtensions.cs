using System;

namespace Blog.Core.Repository.Filters
{
    public static class DateColumnExtensions
    {     
        public static void EqualTo(this DateColumn dateColumn, DateTime date)
        {
            dateColumn.Value = date;
            dateColumn.Operator = DateColumn.Operators.EqualTo;
        }

        public static void Between(this DateColumn dateColumn, DateTime from, DateTime to)
        {
            dateColumn.From = from;
            dateColumn.To = to;
            dateColumn.Operator = DateColumn.Operators.Between;
        }
    }
}
