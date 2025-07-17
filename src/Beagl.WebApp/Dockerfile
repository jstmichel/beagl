# Multi-stage build for Beagl.WebApp
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/Beagl.WebApp/Beagl.WebApp.csproj src/Beagl.WebApp/
RUN dotnet restore src/Beagl.WebApp/Beagl.WebApp.csproj
COPY . .
RUN dotnet publish src/Beagl.WebApp/Beagl.WebApp.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Beagl.WebApp.dll"]
