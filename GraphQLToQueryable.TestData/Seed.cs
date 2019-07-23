using System.Collections.Generic;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.TestData
{
    public static class Seed
    {
        public static RootEntity TestData()
        {
            var child1 = new ChildEntity("CHILD_1");
            var child2 = new ChildEntity("CHILD_2");

            var other = new OtherEntity("OTHER", new List<ChildEntity>{child1, child2});
            
            return new RootEntity("NAME_1", other);
        }
    }
}
