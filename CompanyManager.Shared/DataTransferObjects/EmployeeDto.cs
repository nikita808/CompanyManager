namespace CompanyManager.Shared.DataTransferObjects;

[Serializable]
public class EmployeeDto
{
    public int Id { get; set; }


    public string? Name { get; set; }


    public int Age { get; set; }


    public string? Position { get; set; }
}