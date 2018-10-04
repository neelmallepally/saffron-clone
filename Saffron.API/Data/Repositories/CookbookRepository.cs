using Saffron.API.Data.Abstractions;
using Saffron.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Repositories
{
	public class CookbookRepository : ICookbookRepository
	{
		private readonly ApplicationDbContext _context;

		public CookbookRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<CookbookDAO> Get()
		{
			return _context.Cookbooks;
		}

		public CookbookDAO GetByTitle(string title)
		{
			return _context.Cookbooks.FirstOrDefault(c => c.Equals(title));
		}
	}

	public class RecipeRepository : IRecipeRepository
	{
		private readonly ApplicationDbContext _context;
		public RecipeRepository(ApplicationDbContext context)
		{
			_context = context;
		}
	}
}
