using System.ComponentModel.DataAnnotations;

namespace EventSphere.Core.Models;

public class LoginDto
{
    [EmailAddress]
    public required string Email { get; set; }

    public required string Password { get; set; }
}
