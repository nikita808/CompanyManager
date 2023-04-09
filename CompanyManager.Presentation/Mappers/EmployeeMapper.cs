using CompanyManager.Entities;
using CompanyManager.Shared.DataTransferObjects;

namespace CompanyManager.Presentation.Mappers;

public static class EmployeeMapper
{
    public static EmployeeDto ToDto(Employee employee)
    {
        var dto = new EmployeeDto
        {
            Name = employee.Name,
            Age = employee.Age,
        };

        return dto;
    }
}