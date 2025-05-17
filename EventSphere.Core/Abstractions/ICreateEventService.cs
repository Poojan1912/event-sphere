using EventSphere.Core.Models;

namespace EventSphere.Core.Abstractions;

public interface ICreateEventService
{
    Task CreateEventAsync(CreateEventDto createEvent);
}