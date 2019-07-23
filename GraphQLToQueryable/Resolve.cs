using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace GraphQLToQueryable
{
    public static class Resolve
    {
        public static TTo SingleObject<TFrom, TTo>(IQueryable<TFrom> query, ResolveFieldContext<object> context)
        {
            return QueryToQueryable
                .Resolve<TFrom, TTo>(query, context.SubFields.Values)
                .SingleOrDefault();
        }

        public static IList<TTo> List<TFrom, TTo>(IQueryable<TFrom> query, ResolveFieldContext<object> context)
        {
            return QueryToQueryable
                .Resolve<TFrom, TTo>(query, context.SubFields.Values)
                .ToList();
        }
    }
}
