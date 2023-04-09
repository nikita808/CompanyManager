using CompanyManager.Contracts;
using CompanyManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
    {
        var companies = await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToArrayAsync();

        return companies;
    }
}