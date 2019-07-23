using System.Linq;
using GraphQL;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;

namespace GraphQLToQueryable.EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
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

                var result2 = schema.Execute(_ => _.Query = @"
                    {
                        children {
                            id    
                            name
                        }
                    }
                ");

                var result3 = schema.Execute(_ => _.Query = @"
                    {
                        other {
                            name
                            
                        }
                    }
                ");
            }
        }
    }
}
