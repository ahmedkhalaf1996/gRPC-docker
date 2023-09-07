# Dockerfile for App1 (WebAPI with gRPC)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY server/ .
RUN dotnet restore


RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Copy the SSL certificate
COPY server/https/aspnetapp.pfx /https/aspnetapp.pfx
ENV ASPNETCORE_HTTPS_PORT=5001
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="5747723"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx


EXPOSE 8080
EXPOSE 5001

ENTRYPOINT ["dotnet", "server.dll"]