using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WeoService
{
	public class Program
	{
		public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
		public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(builder =>
			{
				builder.UseStartup<Startup>();
				builder.UseUrls("http://localhost:5010");
			});
	}
}
