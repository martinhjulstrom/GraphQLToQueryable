using GraphQL.Types;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.Tests
{
    public class TestSchema : Schema
    {
        public TestSchema(RootEntity root)
        {
            Query = new TestQuery(root);
        }
    }
}
