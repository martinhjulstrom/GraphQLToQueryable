using GraphQLToQueryable.TestData.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLToQueryable.EfCore
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=GTQCore;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RootEntity>().ToTable("RootEntities");
        }
    }
}
