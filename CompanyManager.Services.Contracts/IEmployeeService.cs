using CompanyManager.Shared.DataTransferObjects;

namespace CompanyManager.Services.Contracts;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployees(int companyId, bool trackChanges);

    Task<EmployeeDto> GetOne(int id, bool trackChanges);
}