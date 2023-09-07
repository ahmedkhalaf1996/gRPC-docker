# Dockerfile for App1 (WebAPI with gRPC)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY server/ .
RUN dotnet restore


RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5055
EXPOSE 5001

ENTRYPOINT ["dotnet", "server.dll"]