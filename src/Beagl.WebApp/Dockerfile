# Multi-stage build for Beagl.WebApp
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all source files for all projects into /src
COPY src/Beagl.Domain/ ./Beagl.Domain/
COPY src/Beagl.Infrastructure/ ./Beagl.Infrastructure/
COPY src/Beagl.WebApp/ ./Beagl.WebApp/

# Restore dependencies
RUN dotnet restore Beagl.WebApp/Beagl.WebApp.csproj

# Copy everything else (if needed, e.g., solution file, configs, etc.)
COPY . .

# Publish the application
RUN dotnet publish Beagl.WebApp/Beagl.WebApp.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Beagl.WebApp.dll"]
