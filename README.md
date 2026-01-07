# GameStore API

A minimal ASP.NET Core Web API for managing games.

Quick facts

- Local URLs (from `GameStore.Api/Properties/launchSettings.json`):
  - HTTP: http://localhost:5000
  - HTTPS: https://localhost:5001
  - Swagger UI : http://localhost:5000/swagger or https://localhost:5001/swagger
  - Scalar UI : http://localhost:5000/scalar or https://localhost:5001/scalar
  - Postman: always (hehe)

Prerequisites

- .NET SDK
- Docker & Docker Compose (only required to run Keycloak)
- Optional: `dotnet-ef` (install with `dotnet tool install --global dotnet-ef`) to apply migrations

Configuration

- Edit connection strings and settings in `GameStore.Api/appsettings.json` or `appsettings.Development.json`.
- Keycloak settings (if used) are configured in the same files — adjust URLs/realm/client as needed.

Quick start (3 steps)

1) Start Keycloak (optional, for authentication)

```powershell
cd GameStore.Api
docker-compose up -d
```

2) Apply database migrations

```powershell
cd GameStore.Api
# ensure connection string in appsettings.json is correct
dotnet ef database update
```

3) Run the API

```powershell
cd GameStore.Api
dotnet run
```

Useful commands

```powershell
# build the project
cd GameStore.Api
dotnet build

# run the project
dotnet run

# show Keycloak logs
docker-compose logs keycloak
```

Where to look

- `GameStore.Api/` — main project
- `GameStore.Api/Controllers/` — API endpoints
- `GameStore.Api/Migrations/` — EF Core migrations
- `GameStore.Api/Properties/launchSettings.json` — local URLs
- `GameStore.Api/appsettings.json` — configuration

Troubleshooting

- Migrations fail: confirm the connection string and that the database server is reachable.
- Keycloak doesn't start: ensure Docker is running and check `docker-compose logs keycloak`.
- Swagger not available: verify Swagger is enabled and use the correct URL/port from `launchSettings.json`.
