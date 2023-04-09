using System.Text.Json;
using CompanyManager.Services.Contracts;
using CompanyManager.Shared.RequestFeatures;
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
    public async Task<IActionResult> GetEmployeesForCompany(int companyId,
        [FromQuery] EmployeeParameters employeeParameters)
    {
        var pagedResult = await _service
            .EmployeeService
            .GetAllEmployees(companyId, employeeParameters, trackChanges:
                false);

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metaData));


        return Ok(pagedResult.employees);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetEmployeeForCompany(int companyId)
    {
        var employee = _service.EmployeeService.GetOne(companyId, false);
        return Ok(employee);
    }
}