using CompanyManager.Contracts;
using CompanyManager.Entities.Models;
using CompanyManager.LoggerService;
using CompanyManager.Repository;
using CompanyManager.Services;
using CompanyManager.Services.Contracts;
using CompanyManager.Shared.HttpClients;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Api.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<DatabaseContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("SqlConnection")));

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureHttpClients(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient<MockHttpClient>();
    }
}