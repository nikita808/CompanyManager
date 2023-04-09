using CompanyManager.Contracts;
using CompanyManager.LoggerService;
using CompanyManager.Repository;
using CompanyManager.Services;
using CompanyManager.Services.Contracts;
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
}