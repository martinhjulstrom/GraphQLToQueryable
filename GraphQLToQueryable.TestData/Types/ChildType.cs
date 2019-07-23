using GraphQL.Types;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.TestData.Types
{
    public class ChildType : ObjectGraphType<ChildDto>
    {
        public ChildType()
        {
            Field<GuidGraphType>("id");
            Field<StringGraphType>("name");
        }
    }
}
