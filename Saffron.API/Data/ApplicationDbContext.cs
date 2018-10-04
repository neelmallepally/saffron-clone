using Microsoft.EntityFrameworkCore;
using Saffron.API.Data.Models;
using Saffron.API.Extensions;

namespace Saffron.API.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		  : base(options)
		{

		}

		public DbSet<CookbookDAO> Cookbooks { get; set; }
		public DbSet<RecipeDAO> Recipes { get; set; }
		public DbSet<CookBookRecipesDAO> CookbookRecipes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CookBookRecipesDAO>()
			  .HasKey(c => new { c.CookbookId, c.RecipeId });

			modelBuilder.Seed();
		}
	}
}
