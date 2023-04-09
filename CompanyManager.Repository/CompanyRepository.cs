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

    public async Task<Company?> GetOne(int id, bool trackChanges)
    {
        var company =
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        return company;
    }
}