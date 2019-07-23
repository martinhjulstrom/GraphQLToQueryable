using GraphQL.Types;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;
using GraphQLToQueryable.TestData.Types;

namespace GraphQLToQueryable.EfCore
{
    public class Query : ObjectGraphType
    {
        public Query(Context dbContext)
        {
            Field(
                typeof(RootType),
                "root",
                "",
                new QueryArguments(),
                context =>
                {
                    var query = dbContext.Set<RootEntity>();

                    return Resolve.SingleObject<RootEntity, RootDto>(query, context);
                });

            Field(
                typeof(ListGraphType<ChildType>),
                "children",
                "",
                new QueryArguments(),
                context =>
                {
                    var query = dbContext.Set<ChildEntity>();

                    return Resolve.List<ChildEntity, ChildDto>(query, context);
                });
        }
    }
}
