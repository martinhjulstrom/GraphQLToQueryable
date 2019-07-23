namespace GraphQLToQueryable.TestData.Entities
{
    public class RootEntity : BaseEntity
    {
        public string Name { get; private set; }
        public OtherEntity Other { get; private set; }

        protected RootEntity() {}

        public RootEntity(string name, OtherEntity other)
        {
            Name = name;
            Other = other;
        }
    }
}
