using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using NOSqlDBWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<CosmosDbSettings>(builder.Configuration.GetSection("CosmosCon"));
builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
    return new CosmosClient(settings.Account, settings.Key);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
