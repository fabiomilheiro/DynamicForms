using System;
using System.Linq;
using System.Linq.Expressions;

namespace DynamicForms.Common.Infrastructure.Extensions
{
    public static class ExpressionExtensions
    {
        public static void SetPropertyValue<TEntity, TProperty>(this TEntity target, Expression<Func<TEntity, TProperty>> memberLambda, TProperty value)
        {
            var setterExpression = CreateSetter(memberLambda);
            setterExpression.Compile()(target, value);
        }

        private static Expression<Action<TEntity, TProperty>> CreateSetter<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> selector)
        {
            var valueParam = Expression.Parameter(typeof(TProperty));
            var conversion = Expression.Convert(valueParam, selector.Body.Type);
            var body = Expression.Assign(selector.Body, conversion);
            return Expression.Lambda<Action<TEntity, TProperty>>(body, selector.Parameters.Single(), valueParam);
        }
    }
}