# Multi-stage build for Beagl.WebApp
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore src/Beagl.WebApp/Beagl.WebApp.csproj
RUN dotnet publish src/Beagl.WebApp/Beagl.WebApp.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Beagl.WebApp.dll"]
