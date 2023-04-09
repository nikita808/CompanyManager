using CompanyManager.Entities;

namespace CompanyManager.Contracts;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
}

public interface IEmployeeRepository
{
}