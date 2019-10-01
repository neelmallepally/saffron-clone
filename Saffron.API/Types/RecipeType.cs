using GraphQL.Types;
using Saffron.Domain;

namespace Saffron.API.Types
{
	public class RecipeType : ObjectGraphType<Recipe>
	{
		public RecipeType()
		{
			Name = "Recipe";

			Field(r => r.Id, type: typeof(IdGraphType)).Description("Id of the recipe");
			Field(r => r.Ingradients, type: typeof(ListGraphType<IngradientType>)).Description("Ingrdients of the recipe");
			Field(r => r.Steps).Description("Instructions to prepare the recipe");
			Field(r => r.PhotoUrl).Description("Image rrl for the recipe");
			Field(r => r.CookingTime, type:typeof(ListGraphType<CookingTimeType>)).Description("Cooking times of the recipe");
			Field(r => r.Description).Description("Description of the recipe");
			Field(r => r.Source).Description("Source of the recipe");
			Field(r => r.SourceUrl).Description("Source url of the recipe");
			Field(r => r.Yield).Description("Output yield of the recipe");

		}
	}
}
