using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddCors();

var app = builder.Build();

/// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.MapGrpcService<SampleService>();
app.MapGrpcReflectionService();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
