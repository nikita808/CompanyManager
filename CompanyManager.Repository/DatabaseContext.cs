using CompanyManager.Entities;
using CompanyManager.Entities.Models;
using CompanyManager.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository;

public class DatabaseContext : IdentityDbContext<User>
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedData();
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }

    public DbSet<Company>? Companies { get; set; }

    public DbSet<Employee>? Employees { get; set; }
}