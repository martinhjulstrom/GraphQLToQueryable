namespace GraphQLToQueryable.EF
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(Context dbContext)
        {
            Query = new Query(dbContext);
        }
    }
}
