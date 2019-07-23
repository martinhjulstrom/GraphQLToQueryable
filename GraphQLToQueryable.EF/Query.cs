using GraphQL.Types;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;
using GraphQLToQueryable.TestData.Types;

namespace GraphQLToQueryable.EF
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
                context => Resolve.SingleObject<RootEntity, RootDto>(dbContext.Set<RootEntity>(), context));

            Field(
                typeof(OtherType),
                "other",
                "",
                new QueryArguments(),
                context => Resolve.SingleObject<OtherEntity, OtherDto>(dbContext.Set<OtherEntity>(), context));

            Field(
                typeof(ListGraphType<ChildType>),
                "children",
                "",
                new QueryArguments(),
                context => Resolve.List<ChildEntity, ChildDto>(dbContext.Set<ChildEntity>(), context));
        }
    }
}
