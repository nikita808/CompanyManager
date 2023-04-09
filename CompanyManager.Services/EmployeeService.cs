using CompanyManager.Contracts;
using CompanyManager.Entities;
using CompanyManager.Entities.Exceptions;
using CompanyManager.LoggerService;
using CompanyManager.Services.Contracts;
using CompanyManager.Services.Mappers;
using CompanyManager.Shared.DataTransferObjects;

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

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(int companyId, bool trackChanges)
    {
        var company = _repository.Company.GetOne(companyId, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeesEntities = await _repository.Employee.GetEmployees(companyId, false);

        var enumerable = employeesEntities as Employee[] ?? employeesEntities.ToArray();

        if (!enumerable.Any())
        {
            return Array.Empty<EmployeeDto>();
        }

        return enumerable.Select(EmployeeMapper.ToDto);
    }

    public async Task<EmployeeDto> GetOne(int id, bool trackChanges)
    {
        var employee = await _repository.Employee.GetOne(id, trackChanges);

        return EmployeeMapper.ToDto(employee);
    }
}