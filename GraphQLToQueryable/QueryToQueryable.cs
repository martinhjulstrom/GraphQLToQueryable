using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GraphQL.Language.AST;

namespace GraphQLToQueryable
{
    internal static class QueryToQueryable
    {
        public static IQueryable<TTo> Resolve<TFrom, TTo>(IQueryable<TFrom> query, IEnumerable<Field> fields)
        {
            var selectBody = GetSelectBody(typeof(TFrom), typeof(TTo), fields);
            var selectMethod = GetSelectMethod(typeof(TFrom), typeof(TTo));
            
            return selectMethod.Invoke(null, new object[] { query, selectBody }) as IQueryable<TTo>;
        }

        private static LambdaExpression GetSelectBody(Type fromType, Type toType, IEnumerable<Field> fields)
        {
            var parameterExpression = Expression.Parameter(fromType);

            var memberInit = GetMemberInit(parameterExpression, fromType, toType, fields);

            var selectLambdaMethod = GetExpressionLambdaMethod(parameterExpression.Type, toType);
            var selectBodyLambdaParameters = new object[] { memberInit, new[] { parameterExpression } };
            
            return (LambdaExpression)selectLambdaMethod.Invoke(null, selectBodyLambdaParameters);
        }

        private static MethodInfo GetExpressionLambdaMethod(Type parameterType, Type toType)
        {
            var prototypeLambdaMethod = GetStaticMethod(() => Expression.Lambda<Func<object, object>>(default(Expression), default(IEnumerable<ParameterExpression>)));
            var lambdaGenericMethodDefinition = prototypeLambdaMethod.GetGenericMethodDefinition();
            var funcType = typeof(Func<,>).MakeGenericType(parameterType, toType);
            var lambdaMethod = lambdaGenericMethodDefinition.MakeGenericMethod(funcType);
            
            return lambdaMethod;
        }

        private static Expression GetMemberInit(Expression entityParameterExpression, Type fromType, Type toType, IEnumerable<Field> fields)
        {
            var constructor = toType.GetConstructors().Single();
            
            var newExpression = Expression.New(constructor);

            var bindings = new List<MemberAssignment>();

            var fromProperties = fromType.GetProperties();
            var toProperties = toType.GetProperties();

            foreach (var field in fields)
            {
                var fromProperty = fromProperties.Single(x => string.Equals(x.Name, field.Name, StringComparison.CurrentCultureIgnoreCase));
                var to = toProperties.Single(x => string.Equals(x.Name, field.Name, StringComparison.CurrentCultureIgnoreCase));

                Expression from = Expression.Property(entityParameterExpression, fromProperty);

                if (field.SelectionSet.Selections.Any())
                {
                    if (typeof(IEnumerable).IsAssignableFrom(to.PropertyType))
                    {
                        var toListType = to.PropertyType.GetGenericArguments()[0];
                        var fromListType = fromProperty.PropertyType.GetGenericArguments()[0];

                        var lambda = GetSelectBody(fromListType, toListType, field.SelectionSet.Selections.Cast<Field>());
                        var select = Expression.Call(typeof(Enumerable), "Select", new[] { fromListType, toListType }, from, lambda);
                        from = Expression.Call(typeof(Enumerable), "ToList", new[] { toListType }, select);
                    }
                    else
                    {
                        from = GetMemberInit(from, fromProperty.PropertyType, to.PropertyType, field.SelectionSet.Selections.Cast<Field>());
                    }
                }

                var bind = Expression.Bind(to, from);
                bindings.Add(bind);
            }

            return Expression.MemberInit(newExpression, bindings);
        }

        private static MethodInfo GetSelectMethod(Type entityType, Type returnType)
        {
            var prototypeSelectMethod = GetStaticMethod(() => Queryable.Select(default(IQueryable<object>), default(Expression<Func<object, object>>)));
            var selectGenericMethodDefinition = prototypeSelectMethod.GetGenericMethodDefinition();
            
            return selectGenericMethodDefinition.MakeGenericMethod(new[] { entityType, returnType });
        }

        private static MethodInfo GetStaticMethod(Expression<Action> expression)
        {
            var lambda = expression as LambdaExpression;
            var methodCallExpression = lambda.Body as MethodCallExpression;
            
            return methodCallExpression.Method;
        }
    }
}
