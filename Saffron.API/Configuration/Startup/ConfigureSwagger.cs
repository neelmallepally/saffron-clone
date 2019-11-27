using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration
{
	public static partial class ConfigureExtensions
	{
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cookbook API", Version = "v1" });
			});

			return services;
		}

		public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger();

			app.UseReDoc(c =>
			{
				c.RoutePrefix = ""; // default prefix is /api-docs. Since our domain already has webapi we are goind to remove default prefix.
				c.SpecUrl = "swagger/v1/swagger.json";
				c.ConfigObject = new Swashbuckle.AspNetCore.ReDoc.ConfigObject()
				{
					AdditionalItems = { { "suppressWarnings", true } },
					HideDownloadButton = true,
					NativeScrollbars = true
				};
			});

			return app;
		}
	}
}
