using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;

namespace ProductManager
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddApiVersioning(o => {
				o.ReportApiVersions = true;
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();
			app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
			{
				settings.GeneratorSettings.DefaultPropertyNameHandling =
					PropertyNameHandling.CamelCase;
			});
			app.UseSwagger(typeof(Startup).Assembly, settings =>
			{
				settings.PostProcess = document =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "ToDo API";
					document.Info.Description = "A simple ASP.NET Core web API";
					document.Info.TermsOfService = "None";
					document.Info.Contact = new NSwag.SwaggerContact
					{
						Name = "Bogdan Yurchak",
						Email = string.Empty,
					};
				};
			});

			app.UseMvc();
			
		}
	}
}
