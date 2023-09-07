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
COPY /https/aspnetapp.pfx /https/aspnetapp.pfx

RUN  ["cat", "/https/aspnetapp.pfx"]


ENV ASPNETCORE_HTTPS_PORT=5001
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="5747723"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx

EXPOSE 5001
EXPOSE 5000

ENTRYPOINT ["dotnet", "server.dll"]