using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Models
{
  [Table("CookingTime")]
  public class CookingTimeDAO
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string TimeTitle { get; set; } // ex: Prep, Cook, Total
    public int Minutes { get; set; }
    public int Hours { get; set; }
    [ForeignKey(nameof(Recipe))]
    public Guid RecipeId { get; set; }
    public virtual RecipeDAO Recipe { get; set; }
  }
}
