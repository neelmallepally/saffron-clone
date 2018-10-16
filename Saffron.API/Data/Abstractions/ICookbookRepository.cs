using Saffron.API.Data.Models;
using Saffron.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Abstractions
{
	public interface ICookbookRepository
	{
		IEnumerable<Cookbook> Get();
		Cookbook GetByTitle(string title);
		Cookbook CreateCookbook(Cookbook cookbook);
	}

	public interface IRecipeRepository
	{

	}
}
