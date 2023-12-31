using Business.Abstract;
using Business.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options =>
             options.UseNpgsql("Host=localhost;Port=5432;Database=Rehber;User Id=postgres;Password=123456;"));

builder.Services.AddScoped<IKisiService, KisiService>();
builder.Services.AddScoped<IIletisimService, IletisimBilgisiService>();
builder.Services.AddScoped<IBilgiTipiService, BilgiTipiService>();
builder.Services.AddScoped<IRaporService, RaporService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("GeneralCors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("GeneralCors");

app.Run();
