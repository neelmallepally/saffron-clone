using GraphQL.Types;
using Saffron.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API.Types
{
  public class CookbookType : ObjectGraphType<Cookbook>
  {
    public CookbookType()
    {
      Field(c => c.Id, type: typeof(IdGraphType)).Description("Id of the Cookbook");
      Field(c => c.Title);
    }
  }
}
