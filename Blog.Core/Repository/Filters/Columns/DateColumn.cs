using System;
using System.Collections.Generic;

namespace Blog.Core.Repository.Filters
{
    public class DateColumn : Column
    {
        public enum Operators
        {
            None = 0,
            EqualTo = 1,
            Between = 3
        }

        public DateTime Value { get; internal set; }

        public DateTime From { get; internal set; }

        public DateTime To { get; internal set; }

        public IEnumerable<DateTime> Range { get; internal set; }

        public Operators Operator { get; internal set; }

        internal DateColumn(string columnName) : base(columnName)
        {
            this.Operator = Operators.None;
        }
    }
}
