namespace GraphQLToQueryable.TestData.Entities
{
    public class ChildEntity : BaseEntity
    {
        public string Name { get; private set; }

        protected ChildEntity() {}

        public ChildEntity(string name)
        {
            Name = name;
        }
    }
}
