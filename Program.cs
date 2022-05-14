using Dot6.API.CosmosDB.Demo.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICarCosmosService>(options =>
{
    string url = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("URL");
    string primaryKey = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("PrimaryKey");
    string dbName = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("DatabaseName");
    string containerName = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("ContainerName");
    var cosmosClient = new CosmosClient(
        url,
        primaryKey
    );
    return new CarCosmosService(cosmosClient, dbName, containerName);
});

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

app.Run();
