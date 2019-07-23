using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GraphQL;
using GraphQLToQueryable.TestData;
using GraphQLToQueryable.TestData.Dtos;
using GraphQLToQueryable.TestData.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GraphQLToQueryable.Tests
{
    [TestClass]
    public class TestEntry
    {
        [TestMethod]
        public void LoadRoot()
        {
            var root = Seed.TestData();
            var schema = new TestSchema(root);

            var query = @"
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
            ";

            var queryResult = schema.Execute(_ => _.Query = query);

            var result = JsonConvert.DeserializeObject<ResultWrapper>(queryResult);

            result.Data.Root.Id.Should().Be(root.Id);
            result.Data.Root.Name.Should().Be(root.Name);
            result.Data.Root.Other.Name.Should().Be(root.Other.Name);

            var children = root.Other.Children.ToList();

            result.Data.Root.Other.Children.ToList()[0].Name.Should().Be(children[0].Name);
            result.Data.Root.Other.Children.ToList()[1].Name.Should().Be(children[1].Name);
        }

        [TestMethod]
        public void LoadChildren()
        {
            var root = Seed.TestData();
            var schema = new TestSchema(root);

            var query = @"
            {
                children {
                    id    
                    name
                }
            }
            ";

            var queryResult = schema.Execute(_ => _.Query = query);

            var result = JsonConvert.DeserializeObject<ChildrenResultWrapper>(queryResult);

            var children = root.Other.Children.ToList();

            result.Data.Children.ToList()[0].Name.Should().Be(children[0].Name);
            result.Data.Children.ToList()[1].Name.Should().Be(children[1].Name);
        }

        private class ResultWrapper
        {
            public DataWrapper Data { get; set; }
        }

        private class DataWrapper
        {
            public RootDto Root { get; set; }
        }

        private class ChildrenResultWrapper
        {
            public ChildrenDataWrapper Data { get; set; }
        }

        private class ChildrenDataWrapper
        {
            public IList<ChildEntity> Children { get; set; }
        }
    }
}
