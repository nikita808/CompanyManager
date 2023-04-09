using System.Text.Json.Serialization;

namespace CompanyManager.Shared.DataTransferObjects;

public class CompanyDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Country { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<EmployeeDto>? Employees { get; set; }
}