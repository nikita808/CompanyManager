using CompanyManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }
}