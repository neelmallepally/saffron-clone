using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Models
{
  [Table("Section")]
  public class SectionDAO
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required, MaxLength(60)]
    public string Title { get; set; }
    [Required]
    public int Order { get; set; } = 1;

    [Required]
    [ForeignKey(nameof(Cookbook))]
    public Guid CookbookId { get; set; }

    public virtual CookbookDAO Cookbook { get; set; }
  }
}
