using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CS68_MVC01.Models
{
	// razorweb.models.MyBlogContext
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			//..
			// this.Roles
			// IdentityRole<string>
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			base.OnConfiguring(builder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			//{
			//	var tableName = entityType.GetTableName();
			//	if (tableName.StartsWith("AspNet"))
			//	{
			//		entityType.SetTableName(tableName.Substring(6));
			//	}
			//}

		}
		public DbSet<Contact> Contacts { get; set; }
	}
}