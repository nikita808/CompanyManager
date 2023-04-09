using CompanyManager.Contracts;
using CompanyManager.Entities;
using CompanyManager.Entities.Exceptions;
using CompanyManager.LoggerService;
using CompanyManager.Services.Contracts;
using CompanyManager.Services.Mappers;
using CompanyManager.Shared.DataTransferObjects;
using CompanyManager.Shared.RequestFeatures;

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

    public async Task<(IEnumerable<EmployeeDto> employees, Metadata metaData)> GetAllEmployees(int companyId,
        EmployeeParameters employeeParameters,
        bool trackChanges)
    {
        if (!employeeParameters.ValidAgeRange)
            throw new MaxAgeRangeBadRequestException();

        var company = _repository.Companies.GetOneAsync(companyId, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeesWithMetadata = await _repository
            .Employees
            .GetEmployeesAsync(companyId, employeeParameters, false);

        return (employeesWithMetadata.Select(EmployeeMapper.ToDto), employeesWithMetadata.Metadata);
    }

    public async Task<EmployeeDto> GetOne(int id, bool trackChanges)
    {
        var employee = await _repository.Employees.GetOneAsync(id, trackChanges);

        return EmployeeMapper.ToDto(employee);
    }
}