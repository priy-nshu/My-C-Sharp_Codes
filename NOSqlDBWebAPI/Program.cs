using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using NOSqlDBWebAPI.Models;
using NOSqlDBWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.Configure<CosmosDbSettings>(builder.Configuration.GetSection("CosmosCon"));
//builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
//{
//    var settings = serviceProvider.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
//    return new CosmosClient(settings.Account, settings.Key);
//});

builder.Services.AddSingleton<CosmosClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new CosmosClient(config["CosmosCon:Account"], config["CosmosCon:Key"]);
});
builder.Services.AddScoped<IEmployeeService,EmployeeService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
