using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PartyInvites.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PartyInvites
{
	public class Startup
	{
		public Startup(IConfiguration config) => Configuration = config;

		public IConfiguration Configuration { get; }

		public void ConfigurationServices(IServiceCollection services)
		{
			services.AddMvc();
			string conString = Configuration["ConnectionStrings:DefaultConnection"];
			services.AddDbContext<DataContext>(options =>
			options.UseSqlServer(conString));
		}

		[Obsolete]
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
	
	}
}
