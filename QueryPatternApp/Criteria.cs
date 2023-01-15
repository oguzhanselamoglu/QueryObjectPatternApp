using System;
using System.Linq.Expressions;

namespace QueryPatternApp
{
	public class Criteria<T>
	{
        string @operator;
        string field;
        object value;
        QueryLogicalOperator queryOperator;

        public QueryLogicalOperator QueryOperator => queryOperator;

        public Criteria(string @operator, string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            this.@operator = @operator;
            this.field = field;
            this.value = value;
            this.queryOperator = queryOperator;
        }
        static string DebugField<TKey>(Expression<Func<T, TKey>> method)
        {
            string field = method.Body.ToString();
            field = field.Remove(0, field.IndexOf(".") + 1);
            return field;
        }

        public static Criteria<T> GreaterThan(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        => new(">", field, value, queryOperator);

        public static Criteria<T> GreaterThan<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new(">", field, value, queryOperator);
        }



        public static Criteria<T> GreaterThanOrEqual(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
            => new(">=", field, value, queryOperator);

        public static Criteria<T> GreaterThanOrEqual<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new(">=", field, value, queryOperator);
        }

        public static Criteria<T> LessThan(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        => new("<", field, value, queryOperator);

        public static Criteria<T> LessThan<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new("<", field, value, queryOperator);
        }
        public static Criteria<T> LessThanOrEqual(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
            => new("<=", field, value, queryOperator);
        public static Criteria<T> LessThanOrEqual<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new("<=", field, value, queryOperator);
        }

        public static Criteria<T> Equal(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
            => new("=", field, value, queryOperator);
        public static Criteria<T> Equal<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new("=", field, value, queryOperator);
        }

        public static Criteria<T> Contains(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
            => new("Like", field, $"%{value}%", queryOperator);
        public static Criteria<T> Contains<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new("Like", field, $"%{value}%", queryOperator);
        }

        public static Criteria<T> StartsWith(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
            => new("Like", field, $"{value}%", queryOperator);
        public static Criteria<T> StartsWith<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = DebugField(method);
            return new("Like", field, $"{value}%", queryOperator);
        }

        public static Criteria<T> EndsWith(string field, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
            => new("Like", field, $"%{value}", queryOperator);
        public static Criteria<T> EndsWith<TKey>(Expression<Func<T, TKey>> method, object value, QueryLogicalOperator queryOperator = QueryLogicalOperator.None)
        {
            string field = method.Body.ToString();
            return new("Like", field, $"%{value}", queryOperator);
        }

        public string GenerateSql()
            => $"{field} {@operator} {(value is int or long or float or decimal ? value : $"'{value}'")}";
    }
}

