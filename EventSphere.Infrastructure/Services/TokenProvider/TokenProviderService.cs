using EventSphere.Core.Abstractions;
using EventSphere.Core.Errors;
using EventSphere.Core.Models;
using EventSphere.Core.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventSphere.Infrastructure.Services.TokenProvider;

public class TokenProviderService(IConfiguration configuration) : ITokenProviderService
{
    private readonly IConfiguration _configuration = configuration;

    public Result<string> Provide(UserDto user)
    {
        var secretKey = _configuration["JWT_SECRET"];
        if (string.IsNullOrEmpty(secretKey))
        {
            return Result<string>.Failure(AuthErrors.jwtSecretNotFound);
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
            ]),
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = credentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return Result<string>.Success(tokenHandler.WriteToken(securityToken));
    }
}
