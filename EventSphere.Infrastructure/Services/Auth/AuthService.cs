using EventSphere.Core.Abstractions;
using EventSphere.Core.Errors;
using EventSphere.Core.Models;
using EventSphere.Core.Primitives;
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

    public async Task<Result<string>> LoginAsync(Login login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(LoginErrors.invalidCredentials);
        }

        var identityUser = await _userManager.FindByEmailAsync(login.Email);
        if (identityUser is null)
        {
            return Result<string>.Failure(LoginErrors.userNotFound);
        }

        if (string.IsNullOrEmpty(identityUser.Email))
        {
            return Result<string>.Failure(LoginErrors.userEmailNotFound);
        }

        var user = new User
        {
            Id = identityUser.Id,
            Email = identityUser.Email
        };

        return _tokenProviderService.Provide(user);
    }
}
