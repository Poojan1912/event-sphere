using EventSphere.Application.Models;

namespace EventSphere.Application.Abstractions;

public interface IAuthService
{
    Task<string> LoginAsync(Login login);
}
