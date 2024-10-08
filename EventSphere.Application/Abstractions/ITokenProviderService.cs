using EventSphere.Application.Models;

namespace EventSphere.Application.Abstractions;

public interface ITokenProviderService
{
    string Provide(User user);
}
