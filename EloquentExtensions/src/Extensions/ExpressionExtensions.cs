// Eithery: Eloquent Extensions
// Class ExpressionExtensions
// Contains extension methods for System.Linq.Expressions.Expression class
//
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace EloquentExtensions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Extracts the property name from the given property expression
        /// </summary>
        /// <typeparam name="T">The property type</typeparam>
        /// <param name="propertyExpression">The property expression</param>
        /// <returns>A string property name</returns>
        public static string GetPropertyName<T>(this Expression<Func<T>> propertyExpression)
        {
            Guard.NotNull(propertyExpression, nameof(propertyExpression));
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                RaiseInvalidPropertyExpressionError();
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
                RaiseInvalidPropertyExpressionError();
            if (propertyInfo.IsStatic())
                throw new ArgumentException("The property expression should not be static", "propertyExpression");
            return propertyInfo.Name;
        }


        private static void RaiseInvalidPropertyExpressionError() =>
            throw new ArgumentException("The expression is not a property access expression", "propertyExpression");
    }
}
