using EventSphere.Application.Abstractions;
using EventSphere.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login login)
    {
        var result = await _authService.LoginAsync(login);
        return Ok(result);
    }
}
