using GraphQL.Types;
using Saffron.API.Domain;

namespace Saffron.API.Types
{
	public class SectionType: ObjectGraphType<Section>
	{
		public SectionType()
		{
			Name = "Section";

			Field(c => c.Id, type: typeof(IdGraphType)).Description("Id of the section");
			Field(c => c.Order).Description("The order of the section in a cookbook");
			Field(c => c.Title).Description("The title of the section in a cookbook");
			Field(c => c.Recipes, type: typeof(ListGraphType<RecipeType>)).Description("Recipes in the section");
		}
	}
}
