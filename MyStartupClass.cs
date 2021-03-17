﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HW1
{
	public class MyStartupClass
	{
		private readonly IConfiguration _configuration;

		public MyStartupClass (IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync(_configuration["Microsoft.Hosting.Lifetime"]);
				});
			});
		}
	}

}
