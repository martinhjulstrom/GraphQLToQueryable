using GraphQL.Types;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.TestData.Types
{
    public class RootType : ObjectGraphType<RootDto>
    {
        public RootType()
        {
            Field<GuidGraphType>("id");
            Field<StringGraphType>("name");
            Field<OtherType>("other");
        }
    }
}
