using HttpTriggers.Models;
using HttpTriggers.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddDbContext<BykeStoresContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BykeCon")));
builder.Services.AddDbContext<SchoolDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolCon")));

builder.Services.AddDbContext<MydatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SalesLT"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // Tells EF Core to automatically retry if the database is asleep or drops connection
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
