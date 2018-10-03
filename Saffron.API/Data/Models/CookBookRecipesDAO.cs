using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Models
{

  [Table("CookBookRecipeBind")]
  public class CookBookRecipesDAO
  {
    public Guid CookbookId { get; set; }
    public Guid RecipeId { get; set; }

    public virtual CookbookDAO Cookbook { get; set; }
    public virtual RecipeDAO Recipe { get; set; }

  }
}
