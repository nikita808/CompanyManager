using CompanyManager.Shared.DataTransferObjects;
using CompanyManager.Shared.RequestFeatures;

namespace CompanyManager.Services.Contracts;

public interface IEmployeeService
{
    Task<(IEnumerable<EmployeeDto> employees, Metadata metaData)> GetAllEmployees(int companyId,
        EmployeeParameters employeeParameters,
        bool trackChanges);

    Task<EmployeeDto> GetOne(int id, bool trackChanges);
}