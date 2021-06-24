using Microsoft.EntityFrameworkCore;

namespace WeoService.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
		public DbSet<Weo> Weos { get; set; }
	}
}
