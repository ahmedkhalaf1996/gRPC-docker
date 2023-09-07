# Dockerfile for App2 (WebAPI with gRPC)
    FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
    WORKDIR /app

    COPY client/ .
    RUN dotnet restore

    RUN dotnet publish -c Release -o out

    FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
    WORKDIR /app
    COPY --from=build /app/out ./

    EXPOSE 80
    ENTRYPOINT ["dotnet", "client.dll"]


# Dockerfile for App1 (WebAPI with gRPC)
    FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
    WORKDIR /app

    COPY server/ .
    RUN dotnet restore


    RUN dotnet publish -c Release -o out

    FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
    WORKDIR /app
    COPY --from=build /app/out ./

    EXPOSE 80
    ENTRYPOINT ["dotnet", "server.dll"]



docker-compose code 
    version: '3'
    services:
    server:
        image: ahmedkhalaf666/grpc-docker-server
        ports:
        - "5001:80"  # Map container port 80 to host port 5001

    client:
        image: ahmedkhalaf666/grpc-docker-client
        ports:
        - "5002:80"  # Map container port 80 to host port 5002
        depends_on:
        - server


client service

    private readonly GrpcChannel _channel;
    private readonly Sample.SampleClient _client;

    public SampleServiceClient()
    {
        _channel = GrpcChannel.ForAddress("http://server:80");
        _client = new Sample.SampleClient(_channel);
    }

    public async Task<string> GetApp1Data()
    {
        var request = new SampleRequest{
            Id = "hello Ahmed 8-089-089-8-809"
        };
        var response = await _client.GetDataAsync(request);
        return response.Message;
    }
