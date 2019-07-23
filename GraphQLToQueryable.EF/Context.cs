using System.Data.Entity;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.EF
{
    public class Context : DbContext
    {
        public Context() : base("ConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RootEntity>();
        }
    }
}
