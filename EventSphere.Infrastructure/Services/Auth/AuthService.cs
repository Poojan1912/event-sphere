using EventSphere.Application.Abstractions;
using EventSphere.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace EventSphere.Infrastructure.Services.Auth;

public class AuthService(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    ITokenProviderService tokenProviderService
) : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;
    private readonly ITokenProviderService _tokenProviderService = tokenProviderService;

    public async Task<string> LoginAsync(Login login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.Email!, login.Password!, false, false);
        if (!result.Succeeded)
        {
            throw new Exception("Invalid login attempt.");
        }

        var identityUser = await _userManager.FindByEmailAsync(login.Email!) ?? throw new Exception("User not found.");

        var user = new User
        {
            Id = identityUser.Id,
            Email = identityUser.Email,
            PhoneNumber = identityUser.PhoneNumber
        };

        return _tokenProviderService.Provide(user);
    }
}
