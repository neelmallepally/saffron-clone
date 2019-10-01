using Saffron.Data.Models;
using Saffron.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.Data.Abstractions
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
