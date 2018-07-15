using Blog.Core.Repository.Filters;
using System.Linq;

namespace Blog.Persistance.Queries
{
    public static class SqlFilterGenerator
    {
        public static string GenerateSql(dynamic filter)
        {
            var query = "WHERE 1 = 1";
            var properties = filter.GetType().GetProperties();

            foreach(var property in properties)
            {
                query += Handle(property.GetValue(filter));
            }

            return query;
        }

        private static string Handle(IntegerColumn column)
        {
            if (column.Operator == IntegerColumn.Operators.None)
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
                return string.Format(" AND {0} {1} '{2}'", column.Name, GetOperator(column.Operator), column.Value);
            }
        }

        private static string Handle(DateColumn column)
        {
            var query = string.Empty;

            if (column.Operator == DateColumn.Operators.None)
            {
                return query;
            }

            if (column.Operator == DateColumn.Operators.EqualTo)
            {
                query = string.Format(" AND ({0} >= '{1} 00:00:00.000' AND {0} < '{2} 00:00:00.000')", column.Name, column.Value.ToString("yyyy-MM-dd"), column.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (column.Operator == DateColumn.Operators.Between)
            {
                query = string.Format(" AND ({0} BETWEEN '{1} 00:00:00.000' AND '{2} 00:00:00.000')", column.Name, column.From.ToString("yyyy-MM-dd"), column.To.ToString("yyyy-MM-dd"));
            }
            
            return query;
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
    }
}
