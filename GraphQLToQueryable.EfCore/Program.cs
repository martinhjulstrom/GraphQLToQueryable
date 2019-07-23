using System;
using System.Linq;
using GraphQL;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.EfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                //context.Set<RootEntity>()
                //    .Add(TestData.Seed.TestData());

                //context.SaveChanges();

                var schema = new Schema(context);

                var result = schema.Execute(_ => _.Query = @"
                    {
                        root {
                            id    
                            name
                            
                            other {
                                name

                                children {
                                    name
                                }
                            }
                        }
                    }
                ");
            }
        }
    }
}
