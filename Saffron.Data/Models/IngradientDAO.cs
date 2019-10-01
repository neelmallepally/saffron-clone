using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.Data.Models
{
  [Table("Ingradient")]
  public class IngradientDAO
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, MaxLength(256)]
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Units { get; set; }
    public string Keywords { get; set; }
    [ForeignKey(nameof(Recipe))]
    public Guid RecipeId { get; set; }
    public virtual RecipeDAO Recipe { get; set; }
  }
}
