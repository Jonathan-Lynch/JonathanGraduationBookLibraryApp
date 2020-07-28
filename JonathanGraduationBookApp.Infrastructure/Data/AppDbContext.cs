using JonathanGraduationBookApp.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace JonathanGraduationBookApp.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

		// This method runs once when the DbContext is first used.
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=books.db");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

	}
}
