namespace CompanyManager.Services.Contracts;

public interface IServiceManager
{
    ICompanyService CompanyService { get; }

    IEmployeeService EmployeeService { get; }
}