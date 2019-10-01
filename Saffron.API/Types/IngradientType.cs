using GraphQL.Types;
using Saffron.Domain;

namespace Saffron.API.Types
{
	public class IngradientType : ObjectGraphType<Ingradient>
	{
		public IngradientType()
		{
			Name = "Ingradient";

			Field(i => i.Name).Description("Name of the ingradient");
			Field(i => i.Quantity).Description("Quantity of the ingradient");
			Field(i => i.Units).Description("Units for the ingradient quantity");
			Field(i => i.Keywords).Description("Keywords for the ingradient");
		}
	}
}
