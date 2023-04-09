using CompanyManager.Contracts;
using CompanyManager.Entities;

namespace CompanyManager.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DatabaseContext repositoryContext)
        : base(repositoryContext)
    {
    }
}