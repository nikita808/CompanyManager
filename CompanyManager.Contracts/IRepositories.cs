using CompanyManager.Entities;

namespace CompanyManager.Contracts;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);

    Task<Company?> GetOne(int id, bool trackChanges);
}

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployees(int companyId, bool trackChanges);

    Task<Employee> GetOne(int id, bool trackChanges);
}