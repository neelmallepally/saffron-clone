using GraphQL.Types;
using Saffron.Domain;

namespace Saffron.API.Types
{
	public class CookbookType : ObjectGraphType<Cookbook>
	{
		public CookbookType()
		{
			Name = "Cookbook";

			Field(c => c.Id, type: typeof(IdGraphType)).Description("Id of the cookbook");
			Field(c => c.Title).Description("The name of the cookbook");
			Field(c => c.Sections, type: typeof(ListGraphType<SectionType>)).Description("The sections of the cookbook");
		}
	}
}
