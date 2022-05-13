global using Microsoft.EntityFrameworkCore;
global using GeoJSONAPI.Data;
global using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GeoJSONAPI.Models;
using GeoJSONAPI.Utilities;
using GeoJSONAPI.Context;
using GeoJSONAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("3DPMConnection")));
builder.Services.AddSingleton<JsonFile>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<GeoRepository>();
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

app.MapGet("/weatherforecast", () =>
{
    var JsonFile1 = new JsonFile();
    var result = JsonFile1.LoadJson<GeoObject>("C:\\Users\\ehmseto_01\\Desktop\\work\\3DPOI\\Region_District_Area_WGS1984.geojson");
    var context = new DapperContext(builder.Configuration);
    var resp = new GeoRepository(context);
    resp.CreateGeoObject(result);
    })
.WithName("GetWeatherForecast");

app.Run();

