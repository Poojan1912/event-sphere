using EventSphere.Core.Models;

namespace EventSphere.Core.Abstractions;

public interface ITokenProviderService
{
    string Provide(User user);
}
