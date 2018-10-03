using System;
using System.Collections.Generic;

namespace Saffron.API.Domain
{
  public class Recipe
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IList<Ingradient> Ingradients { get; set; } = new List<Ingradient>();
    public string Steps { get; set; }
    public string PhotoUrl { get; set; }
    public IList<CookingTime> CookingTime { get; set; } = new List<CookingTime>();
    public string Description { get; set; }
    public string Source { get; set; }
    public string SourceUrl { get; set; }
    public string Yield { get; set; } // ex: Servers 4 people, 6 pancakes etc
  }
}
