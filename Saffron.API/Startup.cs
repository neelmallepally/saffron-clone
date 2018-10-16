using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saffron.API.Data;
using Saffron.API.Data.Abstractions;
using Saffron.API.Data.Repositories;
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

			services.AddScoped<ICookbookRepository, CookbookRepository>();
			services.AddScoped<IRecipeRepository, RecipeRepository>();

			services.AddScoped<IDocumentWriter, DocumentWriter>();
			services.AddScoped<IDocumentExecuter, DocumentExecuter>();

			services.AddScoped<SaffronQuery>();
			services.AddScoped<SaffronMutation>();
			services.AddScoped<ISchema, SaffronSchema>();
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
