using EventSphere.Core.Abstractions;
using EventSphere.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(
        [FromBody] CreateEventDto createEvent,
        [FromServices] ICreateEventService createEventService)
    {
        await createEventService.CreateEventAsync(createEvent);
        return Ok();
    }
}
