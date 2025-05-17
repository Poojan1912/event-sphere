namespace EventSphere.Core.Models;

public class CreateEventDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
}