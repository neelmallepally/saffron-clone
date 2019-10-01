using Microsoft.EntityFrameworkCore;
using Saffron.Data.Models;
using Saffron.Data.Extensions;

namespace Saffron.Data
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
