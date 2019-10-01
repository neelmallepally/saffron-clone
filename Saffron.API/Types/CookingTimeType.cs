using GraphQL.Types;
using Saffron.Domain;

namespace Saffron.API.Types
{
	public class CookingTimeType : ObjectGraphType<CookingTime>
	{
		public CookingTimeType()
		{
			Name = "Cooking Time";

			Field(ct => ct.TimeTitle).Description("Cooking time type. Ex: Prep, Cooking etc");
			Field(ct => ct.Hours).Description("Cooking time in hours");
			Field(ct => ct.Minutes).Description("Cooking time in minutes");
		}
	}
}
