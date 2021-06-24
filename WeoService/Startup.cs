using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeoService.Models;

namespace WeoService
{
	public class Startup
	{
		public Startup(IConfiguration config) => Config = config;
		public IConfiguration Config { get; }
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(Config.GetConnectionString("DefaultConnection"));
			});
			services.AddCors(options =>
			{
				options.AddPolicy(
					name: "DefaultPolicy",
					builder =>
					{
						builder.WithOrigins("http://localhost:5000");
					}
				);
			});
			services.AddControllers();
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseRouting();
			app.UseCors("DefaultPolicy");
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
