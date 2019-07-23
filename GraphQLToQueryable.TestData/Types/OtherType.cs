using GraphQL.Types;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.TestData.Types
{
    public class OtherType : ObjectGraphType<OtherDto>
    {
        public OtherType()
        {
            Field<GuidGraphType>("id");
            Field<StringGraphType>("name");
            Field<ListGraphType<ChildType>> ("children");
        }
    }
}
