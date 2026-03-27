using Microsoft.EntityFrameworkCore;
using SchoolDBCoreWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolDBContext>(options =>
                                    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolCon")));

var app = builder.Build(); //gives webapp object

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
