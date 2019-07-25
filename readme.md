# GraphQLToQueryable

This project translates a [GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet) query to an IQueryable select.

More precisely it will translate the following query:

```

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

```

Into the following select:

```csharp

query
	.Select(root => new RootDto
	{
		Id = root.Id,
		Name = root.Name,

		Other = new OtherDto
		{
			Name = root.Other.Name,
			Children = root.Other.Children
				.Select(child => new ChildDto
				{
					Name = child.Name
				})
				.ToList()
		}
	})
	.Single();

```

## Installation

The package is available via nuget [GraphQLToQueryable](https://www.nuget.org/packages/GraphQLToQueryable/) 

## Usage

The package contains a static class named Resolve, which contains two methods SingleObject to resolve a single object and List to resolve a list. The methods has two type parameters, the first is the type to convert from and the second the type to convert to. The first parameter is an IQueryable and the second is the ResolveFieldContext. Two working examples of Entity Framework and Entity Framework Core are included in the project.

```csharp

Resolve.SingleObject<Entity, Dto>(query, context)

```

## Limitations

- The type that you map to must have only one constructor with no parameters.
- The fields that you map from and to must have the same names (and types). These are also the names that can be used in queries.

## Credits

This project builds on examples from [LatticeUtils](https://github.com/dotlattice/LatticeUtils)