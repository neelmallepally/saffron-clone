using GraphQL;
using GraphQL.Types;

namespace Saffron.API
{
	public class SaffronSchema : Schema
	{
		public SaffronSchema(SaffronQuery query, SaffronMutation mutation)
		{
			Query = query;
			Mutation = mutation;
		}
	}
}
