using Blog.Core.Repository.Filters;
using System.Linq;

namespace Blog.Persistance.Queries
{
    public static class SqlFilterGenerator
    {
        public static void GenerateSql(dynamic filter, ref string query)
        {
            query = string.Empty;
            var properties = filter.GetType().GetProperties();

            foreach(var property in properties)
            {
                query += Handle(property.GetValue(filter));
            }
        }

        private static string Handle(IntegerColumn column)
        {
            if(column.Operator == IntegerColumn.Operators.None)
            {
                return string.Empty;
            }

            if (column.Operator == IntegerColumn.Operators.In)
            {
                return string.Format(" AND {0} IN({1})", column.Name, string.Join(",", column.Range));
            }
            else
            {
                return string.Format(" AND {0} {1} {2}", column.Name, GetOperator(column.Operator), column.Value);
            }
        }

        private static string Handle(TextColumn column)
        {
            if (column.Operator == TextColumn.Operators.None)
            {
                return string.Empty;
            }

            if (column.Operator == TextColumn.Operators.In)
            {
                return string.Format(" AND {0} IN({1})", column.Name, string.Join(",", column.Range.Select(o => string.Format("'{0}'", o))));
            }
            else
            {
                return string.Format(" AND {0} {1} {2}", column.Name, GetOperator(column.Operator), column.Value);
            }
        }

        private static string Handle(DateColumn column)
        {
            return string.Empty;

            if (column.Operator == DateColumn.Operators.None)
            {
                return string.Empty;
            }
        }

        public static string GetOperator(IntegerColumn.Operators @operator)
        {
            var result = string.Empty;

            switch (@operator)
            {
                case IntegerColumn.Operators.EqualTo:
                    result = "=";
                    break;
                case IntegerColumn.Operators.GreaterThan:
                    result = ">";
                    break;
                case IntegerColumn.Operators.GreaterThanOrEqualTo:
                    result = ">=";
                    break;
                case IntegerColumn.Operators.In:
                    result = "IN";
                    break;
                case IntegerColumn.Operators.LessThanOrEqualTo:
                    result = "<=";
                    break;
                case IntegerColumn.Operators.LessThan:
                    result = "<";
                    break;
                case IntegerColumn.Operators.NotEqualTo:
                    result = "<>";
                    break;
            }

            return result;
        }

        public static string GetOperator(TextColumn.Operators @operator)
        {
            var result = string.Empty;

            switch (@operator)
            {
                case TextColumn.Operators.In:
                    result = "IN";
                    break;
                case TextColumn.Operators.Like:
                    result = "LIKE";
                    break;
                case TextColumn.Operators.NotLike:
                    result = "NOT LIKE";
                    break;
            }

            return result;
        }

        public static string GetOperator(DateColumn.Operators @operator)
        {
            var result = string.Empty;

            switch (@operator)
            {
                case DateColumn.Operators.In:
                    result = "IN";
                    break;
                case DateColumn.Operators.Between:
                    result = "BETWEEN";
                    break;
                case DateColumn.Operators.Like:
                    result = "LIKE";
                    break;
                case DateColumn.Operators.NotLike:
                    result = "NOT LIKE";
                    break;
            }

            return result;
        }
    }
}
