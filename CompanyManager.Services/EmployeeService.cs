using CompanyManager.Contracts;
using CompanyManager.LoggerService;
using CompanyManager.Services.Contracts;

namespace CompanyManager.Services;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public EmployeeService(IRepositoryManager repository, ILoggerManager
        logger)
    {
        _repository = repository;
        _logger = logger;
    }
}