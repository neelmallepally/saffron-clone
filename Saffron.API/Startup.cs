using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Saffron.API.Data;
using Saffron.API.Middleware;

namespace Saffron.API
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      //TODO: move connection string value to configuration file
      var connection = @"Server=(localdb)\mssqllocaldb;Database=SaffronClone;Trusted_Connection=True;ConnectRetryCount=0";
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

      services.AddSingleton<IDocumentWriter, DocumentWriter>();
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

      services.AddSingleton<HelloWorldQuery>();
      services.AddSingleton<ISchema, HelloWorldSchema>();
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMiddleware<GraphQLMiddleware>();
    }
  }
}
