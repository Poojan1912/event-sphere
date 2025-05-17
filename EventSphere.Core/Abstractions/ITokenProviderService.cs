using EventSphere.Core.Models;
using EventSphere.Core.Primitives;

namespace EventSphere.Core.Abstractions;

public interface ITokenProviderService
{
    Result<string> Provide(UserDto user);
}
