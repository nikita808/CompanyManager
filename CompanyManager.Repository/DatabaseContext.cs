using CompanyManager.Entities;
using CompanyManager.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SeedData();
    }

    public DbSet<Company>? Companies { get; set; }

    public DbSet<Employee>? Employees { get; set; }
}