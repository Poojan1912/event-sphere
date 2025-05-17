using EventSphere.Core.Services;
using EventSphere.Infrastructure.Database;
using EventSphere.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
var allowedOrigin = builder.Configuration.GetValue<string>("ClientApp") ?? "";

// Service registration for Dependency Injection
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowSpecificOrigins", policy =>
    {
        policy.WithOrigins(allowedOrigin)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEventSphereCoreServices();

var app = builder.Build();

// Request Processing Pipeline configuration
app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
