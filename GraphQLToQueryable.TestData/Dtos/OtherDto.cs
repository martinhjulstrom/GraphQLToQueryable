using System;
using System.Collections.Generic;

namespace GraphQLToQueryable.TestData.Dtos
{
    public class OtherDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ChildDto> Children { get; set; }
    }
}
