using EventSphere.Core.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace EventSphere.Infrastructure.Models;

public class ApplicationUser : IdentityUser, IApplicationUser 
{
}
