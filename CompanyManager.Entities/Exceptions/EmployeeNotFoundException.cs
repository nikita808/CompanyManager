namespace CompanyManager.Entities.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int employeeId) : base(
        $"An employee with id {employeeId} does not exist in the database")
    {
    }
}