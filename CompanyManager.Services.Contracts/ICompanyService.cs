using CompanyManager.Entities;

namespace CompanyManager.Services.Contracts;

public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
}