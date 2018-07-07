using System;
using System.Collections.Generic;

namespace Blog.Core.Repository.Filters
{
    public static class DateColumnExtensions
    {     
        public static void Like(this DateColumn dateColumn, DateTime date)
        {
            dateColumn.Value = date;
            dateColumn.Operator = DateColumn.Operators.Like;
        }

        public static void NotLike(this DateColumn dateColumn, DateTime date)
        {
            dateColumn.Value = date;
            dateColumn.Operator = DateColumn.Operators.NotLike;
        }

        public static void In(this DateColumn dateColumn, IEnumerable<DateTime> dates)
        {
            dateColumn.Range = dates;
            dateColumn.Operator = DateColumn.Operators.In;
        }

        public static void Between(this DateColumn dateColumn, DateTime from, DateTime to)
        {
            dateColumn.From = from;
            dateColumn.To = to;
            dateColumn.Operator = DateColumn.Operators.Between;
        }
    }
}
