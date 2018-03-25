using Microsoft.EntityFrameworkCore;

namespace DefaultProject.Infra.Context
{
	public class DefaultProjectDbContext : DbContext
	{
		public DefaultProjectDbContext(DbContextOptions options) 
			: base(options)
		{}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			base.OnModelCreating(modelBuilder);
		}
	}
}