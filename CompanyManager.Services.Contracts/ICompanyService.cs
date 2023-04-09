using CompanyManager.Shared.DataTransferObjects;

namespace CompanyManager.Services.Contracts;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);

    Task<CompanyDto> GetOne(int id, bool trackChanges);

    Task CreateOne(CompanyDto companyDto);
}