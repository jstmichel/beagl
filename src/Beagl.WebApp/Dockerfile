# Multi-stage build for Beagl.WebApp
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all project files for restore
COPY src/Beagl.Domain/Beagl.Domain.csproj src/Beagl.Domain/
COPY src/Beagl.Infrastructure/Beagl.Infrastructure.csproj src/Beagl.Infrastructure/
COPY src/Beagl.WebApp/Beagl.WebApp.csproj src/Beagl.WebApp/

# Restore dependencies
RUN dotnet restore src/Beagl.WebApp/Beagl.WebApp.csproj

# Copy everything else
COPY . .

# Publish the application
RUN dotnet publish src/Beagl.WebApp/Beagl.WebApp.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Beagl.WebApp.dll"]
