# Dockerfile for App2 (WebAPI with gRPC)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY client/ .
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 8090
ENTRYPOINT ["dotnet", "client.dll"]
