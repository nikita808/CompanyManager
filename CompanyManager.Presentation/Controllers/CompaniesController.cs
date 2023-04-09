using CompanyManager.Presentation.Mappers;
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
        try
        {
            var companies =
                await _service.CompanyService.GetAllCompanies(trackChanges: false);

            return Ok(companies.Select(CompanyMapper.ToDto));
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}