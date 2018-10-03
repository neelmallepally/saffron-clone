using System.Collections.Generic;

namespace Saffron.API.Domain
{
  public class Ingradient
  {
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Units { get; set; }
    public IList<string> Keywords { get; set; } = new List<string>();

    public Recipe Recipe { get; set; }
  }
}
