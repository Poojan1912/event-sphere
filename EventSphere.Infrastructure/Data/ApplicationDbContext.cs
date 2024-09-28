using Microsoft.EntityFrameworkCore;

namespace EventSphere.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
}
