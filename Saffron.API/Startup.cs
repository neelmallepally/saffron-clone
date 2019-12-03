﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saffron.API.Data;
using Saffron.API.Infrastructure;

namespace Saffron.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSwagger();
			services.AddCorsPolicy(Configuration);

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddAutoMapper(typeof(Startup));
			services.AddMediatR(typeof(Startup));

			services.AddTransient<ISqlConnectionFactory>(provider => new SqlConnectionFactory(Configuration.GetConnectionString("DefaultConnection")));

		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.ConfigureSwagger();
			app.UseCorsPolicy();


			app.UseDefaultFiles();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseHttpsRedirection();
			}
			app.UseMvc();

		}
	}
}
