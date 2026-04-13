using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;
using ProductWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProductCon")));

builder.Services.AddTransient<IBrandService, BrandService>();
//builder.Services.AddScoped<IBrandService, BrandService>(); //Once per Scope
//builder.Services.AddSingleton<IBrandService, BrandService>();//Once per code
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
