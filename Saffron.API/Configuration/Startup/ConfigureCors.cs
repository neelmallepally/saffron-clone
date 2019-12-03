using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration
{
	public static partial class ConfigureExtensions
	{
		private const string SpecificOrigins = "SpecificOrigins";
		public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(SpecificOrigins,
					 builder =>
					 {
						 builder.WithOrigins("http://localhost:4200"); //TO DO: move this to configuration file
					 });
			});

			return services;
		}

		public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
		{
			app.UseCors(SpecificOrigins);
			return app;
		}
	}
}
