using Grpc.Core;
using client.Services;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddGrpc();
// builder.Services.AddSingleton<SampleServiceClient>();
builder.Services.AddSingleton<SampleServiceClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


var sampleServiceClient = app.Services.GetRequiredService<SampleServiceClient>();

// Call the GetApp1Data function
var result = sampleServiceClient.GetApp1Data().GetAwaiter().GetResult();
Console.WriteLine(result);

app.Run();




