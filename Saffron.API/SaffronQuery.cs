using GraphQL.Types;
using Saffron.Data;
using Saffron.Domain;
using Saffron.API.Types;
using System.Linq;

namespace Saffron.API
{
	public class SaffronQuery : ObjectGraphType
	{
		public SaffronQuery(ApplicationDbContext db)
		{
			Name = "Query";

			Field<ListGraphType<CookbookType>>(
				"cookbooks",
				resolve: context =>
				{
					var cookbooksDAO = db.Cookbooks;
					var cookbooks = cookbooksDAO
					.Select(c => new Cookbook()
					{
						Id = c.Id,
						Title = c.Title
					})
					.ToList();

					return cookbooks;
				}
				);

			Field<CookbookType>(
				"cookbook",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" }),
				resolve: context =>
				{
					var title = context.GetArgument<string>("title");
					var cookbookDAO = db.Cookbooks.FirstOrDefault(c => c.Title.Equals(title));

					var cookbook = new Cookbook();
					if (cookbookDAO != null)
					{
						cookbook.Id = cookbookDAO.Id;
						cookbook.Title = cookbookDAO.Title;
					}
					return cookbook;
				}
				);
		}
	}

}
