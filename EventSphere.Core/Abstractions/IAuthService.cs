using EventSphere.Core.Models;
using EventSphere.Core.Primitives;

namespace EventSphere.Core.Abstractions;

public interface IAuthService
{
    Task<Result<string>> LoginAsync(LoginDto login);
}
