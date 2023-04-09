using CompanyManager.Contracts;

namespace CompanyManager.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly DatabaseContext _context;
    
    private readonly Lazy<ICompanyRepository> _companyRepository;
    
    private readonly Lazy<IEmployeeRepository> _employeeRepository;

    public RepositoryManager(DatabaseContext context)
    {
        _context = context;
        _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(context));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(context));
    }

    public ICompanyRepository Company => _companyRepository.Value;
    
    public IEmployeeRepository Employee => _employeeRepository.Value;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

}