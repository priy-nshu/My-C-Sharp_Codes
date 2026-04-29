using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueTriggers.Models;
using QueueTriggers.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.AddDbContext<QueueDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QueueDbCon")));
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Build().Run();
