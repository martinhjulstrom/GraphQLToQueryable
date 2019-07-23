using System;

namespace GraphQLToQueryable.TestData.Dtos
{
    public class RootDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OtherDto Other { get; set; }
    }
}
