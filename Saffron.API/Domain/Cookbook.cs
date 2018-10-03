using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Domain
{
  public class Cookbook
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IList<Section> Sections { get; set; } = new List<Section>();
  }
}
