using GraphQL.Types;
using Saffron.API.Data.Abstractions;
using Saffron.API.Types;

namespace Saffron.API
{
	public class SaffronQuery : ObjectGraphType
	{
		public SaffronQuery(ICookbookRepository cookbookRepo)
		{
			Field<ListGraphType<CookbookType>>(
				"cookbooks",
				resolve: context =>
				{
					return cookbookRepo.Get();
				}
				);

			Field<CookbookType>(
				"cookbook",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" }),
				resolve: context =>
				{
					var title = context.GetArgument<string>("title");
					return cookbookRepo.GetByTitle(title);
				}
				);
		}
	}

}
