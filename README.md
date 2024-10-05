# EventSphere

EventSphere is built using **ASP.NET Core**, **Angular** and **PostgreSQL**, following a 5-layer architecture (Clean Architecture). It implements **ASP.NET Core Identity** for authentication and authorization.

## Project Structure

- **EventSphere.Presentation**: The startup project that handles the API controllers, routing, and middleware. It also contains the Angular application.
- **EventSphere.Infrastructure**: The Infrastructure project is responsible for all interactions with external resources like databases, third-party APIs, and services.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Node.js (LTS)
- PostgreSQL 17 (locally or in a cloud service)
- Visual Studio 2022 or any terminal supporting .NET CLI

### Setting up the Database

Before running the application, you need to set up the connection to the PostgreSQL database and run the required Entity Framework Core migrations.

1. **Create the Database**: Create a new database `EventSphereDB`.

2. **Password Configuration**: For local development, store sensitive data like database password in `secrets.json`. The password stored in secrets.json will directly be added to the connection string.

3. **Update the database**: After successful connection with the database, update the database through the existing migrations using below command:
   ```bash
   dotnet ef database update --project EventSphere.Infrastructure --startup-project EventSphere.Presentation
   ```
   Database should be updated from the root level folder.

### To add a new migration

Migrations should be executed from the root level folder.

1. Open a terminal in Visual Studio (or use your terminal of choice).
2. Run below command:
   ```bash
   dotnet ef migrations add [migrationName] --project EventSphere.Infrastructure --startup-project EventSphere.Presentation
   ```
