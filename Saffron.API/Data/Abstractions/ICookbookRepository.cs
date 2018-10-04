using Saffron.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Abstractions
{
	public interface ICookbookRepository
	{
		IEnumerable<CookbookDAO> Get();
		CookbookDAO GetByTitle(string title);
	}

	public interface IRecipeRepository
	{

	}
}
