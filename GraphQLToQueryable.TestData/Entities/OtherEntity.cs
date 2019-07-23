using System.Collections.Generic;

namespace GraphQLToQueryable.TestData.Entities
{
    public class OtherEntity : BaseEntity
    {
        public string Name { get; private set; }

        public virtual ICollection<ChildEntity> Children { get; private set; }

        protected OtherEntity() {}

        public OtherEntity(string name, ICollection<ChildEntity> children)
        {
            Name = name;
            Children = children;
        }
    }
}
