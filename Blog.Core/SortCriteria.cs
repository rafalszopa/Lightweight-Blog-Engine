using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Blog.Core
{
    public class SortCriteria<T> where T : class
    {
        public List<(string columnName, SortDirection sortDirection)> Criteria { get; private set; }

        public SortCriteria()
        {
            this.Criteria = new List<(string columnName, SortDirection sortDirection)>();
        }

        public SortCriteria<T> OrderBy(Expression<Func<T, object>> expression, SortDirection sortDirection = SortDirection.ASC)
        {
            var member = this.GetMember(expression);
            this.Criteria.Add((columnName: member.Member.Name, sortDirection));

            return this;
        }

        private MemberExpression GetMember(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException("The expression cannot be null.", "expression");
            }

            var member = expression.Body as MemberExpression;

            if (member == null)
            {
                member = (expression.Body as UnaryExpression)?.Operand as MemberExpression;
            }

            if (this.IsSimple(member.Type) == false)
            {
                throw new ArgumentException("Expression must refer to primitive type, string, decimal or DateTime.", "expression");
            }

            if (this.IsFieldOrProperty(member) == false)
            {
                throw new ArgumentException("Expression must be property or field.", "expression");
            }

            return member;
        }

        private bool IsSimple(Type type)
        {
            return type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(decimal)) || type.Equals(typeof(DateTime));
        }

        private bool IsFieldOrProperty(MemberExpression member)
        {
            return member.Member.MemberType == MemberTypes.Field || member.Member.MemberType == MemberTypes.Property;
        }
    }
}
