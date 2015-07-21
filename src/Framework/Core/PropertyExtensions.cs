using System;
using System.Linq.Expressions;

namespace Aurora.Core
{
    public static class PropertyExtensions
    {
        public static string GetName<TClassType, TPropertyType>(this Expression<Func<TClassType, TPropertyType>> property)
        {
            var memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new InvalidCastException("GetName only works on properties");
            }

            return memberExpression.Member.Name;
        }
    }
}