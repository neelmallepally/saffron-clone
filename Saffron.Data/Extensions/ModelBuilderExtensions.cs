using Microsoft.EntityFrameworkCore;
using Saffron.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.Data.Extensions
{
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      var cookbookId = Guid.NewGuid();

      modelBuilder.Entity<CookbookDAO>().HasData(
          new CookbookDAO {  Id = cookbookId, Title ="Indian"}
        );

      var recipeId = Guid.NewGuid();
      modelBuilder.Entity<RecipeDAO>().HasData(
          new RecipeDAO
          {
            Id = recipeId,
            Title ="Chicken Tikka Masala"
          }
        );
    }
  }
}
