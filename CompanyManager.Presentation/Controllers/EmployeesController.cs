using CompanyManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Presentation.Controllers;

[Route("api/companies/{companyId:int}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesForCompany(int companyId)
    {
        var employees = await _service.EmployeeService.GetAllEmployees(companyId, trackChanges:
            false);

        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetEmployeeForCompany(int companyId)
    {
        var employee = _service.EmployeeService.GetOne(companyId, false);
        return Ok(employee);
    }
}