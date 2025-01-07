using AdventureApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using AdventureApp.Mapping;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Thêm dịch vụ cho Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Cấu hình AutoMapper
//builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Kích hoạt Swagger
    app.UseSwagger();

    app.MapOpenApi();

    //Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
