using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Data.Models
{

  [Table("Cookbook")]
  public class CookbookDAO
  {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required, MaxLength(60)]
    public string Title { get; set; }
    public IList<SectionDAO> Sections { get; set; } = new List<SectionDAO>();
  }
}
