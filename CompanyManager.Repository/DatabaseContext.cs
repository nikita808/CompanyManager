using CompanyManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Company>? Companies { get; set; }
    
    public DbSet<Employee>? Employees { get; set; }
}