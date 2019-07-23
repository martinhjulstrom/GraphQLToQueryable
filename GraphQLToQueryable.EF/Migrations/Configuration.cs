using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GraphQLToQueryable.EF.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            if (context.Set<RootEntity>().Any()) return;

            context.Set<RootEntity>().Add(TestData.Seed.TestData());
        }
    }
}
