using CompanyManager.Contracts;
using CompanyManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
    {
        var companies = await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToArrayAsync();

        return companies;
    }

    public async Task<Company?> GetOneAsync(int id, bool trackChanges)
    {
        var company =
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        return company;
    }

    public async Task AddOneAsync(Company company)
    {
        await CreateAsync(company);
    }
}