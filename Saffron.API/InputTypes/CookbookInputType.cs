using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.InputTypes
{
	public class CookbookInputType : InputObjectGraphType
	{
		public CookbookInputType()
		{
			Name = "CookbookInput";
		}
	}
}
