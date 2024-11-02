using EventSphere.Core.Abstractions;
using EventSphere.Infrastructure.Services.Auth;
using EventSphere.Infrastructure.Services.TokenProvider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EventSphere.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = configuration["JWT_SECRET"] ?? throw new InvalidOperationException("JWT Secret is not configured.");
        byte[] key = Encoding.UTF8.GetBytes(secret);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenProviderService, TokenProviderService>();

        return services;
    }
}
