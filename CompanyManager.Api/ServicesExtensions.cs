using CompanyManager.LoggerService;

namespace CompanyManager.Api;

public static class ServicesExtensions
{
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
}