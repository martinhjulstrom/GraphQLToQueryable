namespace GraphQLToQueryable.EfCore
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(Context dbContext)
        {
            Query = new Query(dbContext);
        }
    }
}
