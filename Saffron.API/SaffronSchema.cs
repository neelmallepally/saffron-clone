using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API
{
  public class SaffronSchema : Schema
  {
    public SaffronSchema(SaffronQuery query)
    {
      Query = query;
    }
  }
}
