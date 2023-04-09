using CompanyManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies =
            await _service.CompanyService.GetAllCompanies(trackChanges: false);

        return Ok(companies);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetOne(int id)
    {
        var company = await _service.CompanyService.GetOne(id, trackChanges: false);
        
        return Ok(company);
    }
}