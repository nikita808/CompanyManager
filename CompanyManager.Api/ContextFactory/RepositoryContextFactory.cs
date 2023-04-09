using CompanyManager.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanyManager.Api.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(configuration.GetConnectionString("SqlConnection"),
                b => b.MigrationsAssembly("CompanyManager.Api"));

        return new DatabaseContext(builder.Options);
    }
}