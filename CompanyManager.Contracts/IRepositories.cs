using CompanyManager.Entities;
using CompanyManager.Shared.RequestFeatures;

namespace CompanyManager.Contracts;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);

    Task<Company?> GetOneAsync(int id, bool trackChanges);

    Task AddOneAsync(Company company);
}

public interface IEmployeeRepository
{
    Task<PagedList<Employee>>
        GetEmployeesAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges);

    Task<Employee> GetOneAsync(int id, bool trackChanges);
}