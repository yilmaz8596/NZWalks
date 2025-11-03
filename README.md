# NZWalks API

NZWalks API is a sample .NET 8 REST API that manages walks, regions and user authentication. It uses Entity Framework Core (Code First), ASP.NET Core Identity (EF stores), JWT authentication, Serilog, Swagger and local image hosting.

## Features
- .NET 8
- EF Core (Code First migrations)
- ASP.NET Core Identity (Entity Framework stores)
- JWT authentication
- Serilog logging
- Swagger UI (development only)
- Static files served from `/Images`
- CORS configured for development (AllowAny*)

## Requirements
- .NET 8 SDK
- Visual Studio 2022 or the __dotnet__ CLI
- SQL Server (local, Docker, or Azure SQL)
- For Azure deployments: Azure subscription and appropriate permissions

## Quick start (local)
1. Clone the repo:

**Solution:**
- Do not run migrations during publish if using Managed Identity. Run migrations separately using a local connection or CI/CD pipeline.
- For runtime migrations with Managed Identity, use Azure.Identity and Microsoft.Data.SqlClient to acquire an access token and set it on the SQL connection.

## Project Structure

- `NZWalks.API` — Main Web API project
- `Data` — DbContexts and EF configurations
- `Repositories` — Data access layer
- `Controllers` — API endpoints
- `Mappings` — AutoMapper profiles
- `Images` — Static images folder

## Troubleshooting

- If you get connection string errors during Azure deployment, check your publish profile and connection string format.
- Ensure your JWT settings are correct and the key is sufficiently long.
- Review Serilog logs for runtime errors.

## Contributing

- Open issues for bugs or feature requests.
- Submit pull requests with clear descriptions.

## License

Add a license file (e.g., MIT) if you want to make this repository open source.

---

For more details, see the code and comments in `Program.cs` and related files.