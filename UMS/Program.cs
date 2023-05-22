using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Win32;
using NLog.Filters;
using NLog.Web;
using UMS.Configs;
using UMS.Entities.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add dbContext middleware
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<UMSContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//filter swagger 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "api/", Version = "v1" });

    // Register the custom schema filter
    c.DocumentFilter<SwaggerFilter>();
});


//logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();

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

