using Microsoft.EntityFrameworkCore;
using Saffron.Data.Abstractions;
using Saffron.Data.Models;
using Saffron.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Saffron.Data.Repositories
{
	public class CookbookRepository : ICookbookRepository
	{
		private readonly ApplicationDbContext _context;

		public CookbookRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Cookbook CreateCookbook(Cookbook cookbook)
		{
			var efCookbook = CookbookDAO.FromDomain(cookbook);
			_context.Cookbooks.Add(efCookbook);
			_context.SaveChanges();
			return efCookbook.ToDomain();
		}

		
		IEnumerable<Cookbook> ICookbookRepository.Get()
		{
			var cookbooks = _context.Cookbooks.AsNoTracking();

			return cookbooks.Select(c => c.ToDomain()).ToList();
		}
		

		Cookbook ICookbookRepository.GetByTitle(string title)
		{
			var cookbook = _context.Cookbooks
				.AsNoTracking()
				.SingleOrDefault(c => c.Title.Equals(title));
			return cookbook?.ToDomain();
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
