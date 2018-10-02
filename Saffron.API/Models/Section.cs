using System;
using System.Collections.Generic;

namespace Saffron.API.Models
{
  public class Section
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public Cookbook Cookbook { get; set; }
    public IList<Recipe> Recipes { get; set; }
  }
}
