using Labb3_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_Api.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Person> Persons { get; set; } = null!;
		public DbSet<Interest> Interests { get; set; } = null!;
		public DbSet<Link> Links { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasData(
		new Person { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com", PhoneNumber = "123-456-7890" },
		new Person { Id = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", PhoneNumber = "987-654-3210" }
	);

			// Seed Interests
			modelBuilder.Entity<Interest>().HasData(
				new Interest { Id = 1, Title = "Photography", Description = "Capturing moments through a lens.", },
				new Interest { Id = 2, Title = "Programming", Description = "Writing code to solve problems." }
			);

			// Seed Links
			modelBuilder.Entity<Link>().HasData(
				new { Id = 1, Url = "https://alicephotos.com", PersonId = 1, InterestId = 1 },
				new { Id = 2, Url = "https://bobcodes.io", PersonId = 2, InterestId = 2 }
			);


			base.OnModelCreating(modelBuilder);
		}
	}
}
