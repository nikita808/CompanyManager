using CompanyManager.Contracts;
using CompanyManager.Entities;
using CompanyManager.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DatabaseContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Employee>> GetEmployees(int companyId, bool trackChanges)
    {
        var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name).ToListAsync();

        return employees;
    }

    public async Task<Employee> GetOne(int id, bool trackChanges)
    {
        var employee = await FindByCondition(e => e.Id == id, trackChanges)
            .SingleOrDefaultAsync();

        if (employee is null)
        {
            throw new EmployeeNotFoundException(id);
        }

        return employee;
    }
}