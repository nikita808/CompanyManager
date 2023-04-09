using CompanyManager.Entities;
using CompanyManager.Shared.DataTransferObjects;

namespace CompanyManager.Services.Mappers;

public static class CompanyMapper
{
    public static CompanyDto ToDto(Company company)
    {
        var dto = new CompanyDto
        {
            Name = company.Name,
            Address = company.Address,
            Country = company.Country,
            Employees = company.Employees?.Select(EmployeeMapper.ToDto)
        };
        return dto;
    }
}