using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeoService.Interfaces;

namespace WeoClient
{
	public class Startup
	{
		readonly IConfiguration _config;
		public Startup(IConfiguration config) => _config = config;
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHttpClient<WeoHttpClient>((sp, c) =>
			{
				c.BaseAddress = new Uri("http://localhost:5010");
			});
			services.AddRazorPages();
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
