using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Core.Domain.Models;

namespace SimpleCRUD.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{		
	}

	public DbSet<Person> Persons { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfiguration(new PersonsSeedConfiguration());
	}
}
