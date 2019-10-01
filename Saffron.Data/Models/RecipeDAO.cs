using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.Data.Models
{
  [Table("Recipe")]
  public class RecipeDAO
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required, MaxLength(120)]
    public string Title { get; set; }
    public IList<IngradientDAO> Ingradients { get; set; } = new List<IngradientDAO>();
    public string Steps { get; set; }
    public string PhotoUrl { get; set; }
    public IList<CookingTimeDAO> CookingTime { get; set; } = new List<CookingTimeDAO>();
    public string Description { get; set; }
    public string Source { get; set; }
    public string SourceUrl { get; set; }
    public string Yield { get; set; } // ex: Servers 4 people, 6 pancakes etc
  }
}
