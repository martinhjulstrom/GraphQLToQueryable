using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;
using GraphQLToQueryable.TestData.Types;

namespace GraphQLToQueryable.Tests
{
    public class TestQuery : ObjectGraphType
    {
        public TestQuery(RootEntity root)
        {
            Field(
                typeof(RootType),
                "root",
                "",
                new QueryArguments(),
                context =>
                {
                    
                    var query = new List<RootEntity> {root}.AsQueryable();

                    return Resolve.SingleObject<RootEntity, RootDto>(query, context);
                });

            Field(
                typeof(ListGraphType<ChildType>),
                "children",
                "",
                new QueryArguments(),
                context =>
                {
                    var query = root.Other.Children.AsQueryable();

                    return Resolve.List<ChildEntity, ChildDto>(query, context);
                });
        }
    }
}
