using EventSphere.Core.Abstractions;
using EventSphere.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.Presentation.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related actions.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ResultsControllerBase
{
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// Authenticates a user with the provided login credentials.
    /// </summary>
    /// <param name="login">The login credentials.</param>
    /// <returns>An IActionResult containing the authentication result.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var result = await _authService.LoginAsync(login);
        return HandleResult(result);
    }
}
