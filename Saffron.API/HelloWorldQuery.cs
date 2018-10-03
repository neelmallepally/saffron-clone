using GraphQL.Types;
using Saffron.API.Domain;
using Saffron.API.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.API
{
  public class HelloWorldQuery : ObjectGraphType
  {
    public HelloWorldQuery()
    {
      Field<StringGraphType>(
        name: "hello",
        resolve: context => "world"
        );

      Field<CookbookType>(
        "cookbook",
        arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name= "title" }),
        resolve: context =>
        {
          var title = context.GetArgument<string>("title");
          return new DataSource().GetCookbookByTitle(title);
        }
        );
    }
  }

  //TODO: Remove this temp code below
  public class DataSource
  {
    public IList<Cookbook> Cookbooks { get; set; }

    public DataSource()
    {
      Cookbooks = new List<Cookbook>()
      {
        new Cookbook { Id = Guid.NewGuid(), Title="Breakfast"},
        new Cookbook { Id = Guid.NewGuid(), Title="Lunch"},
        new Cookbook { Id = Guid.NewGuid(), Title="PM Snack"},
        new Cookbook { Id = Guid.NewGuid(), Title="Dinner"}
      };
    }

    public Cookbook GetCookbookByTitle(string title)
    {
      return Cookbooks.FirstOrDefault(c => c.Title.Equals(title));
    }
  }
}
