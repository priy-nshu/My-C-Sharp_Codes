using Microsoft.EntityFrameworkCore;
using OrdersWebAPI.Models;
using OrdersWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("OrderCon")));

builder.Services.AddTransient<IOrderService, OrderService>();
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
