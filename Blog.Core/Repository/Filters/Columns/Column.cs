using System;

namespace Blog.Core.Repository.Filters
{
    public abstract class Column
    {
        public string Name { get; private set; }

        internal Column(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentException("Name of database column cannot be null or empty.", "columnName");
            }

            this.Name = columnName;
        }
    }
}
