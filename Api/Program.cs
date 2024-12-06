using Api.Mappers;
using Api.Models;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.App;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// configuration Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();

// Add services to the container.
// Get JWT configuration from appsettings.json file
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings"); 
builder.Services.Configure<Api.Settings.JwtSettings>(jwtSettingsSection);
var jwtSettings = jwtSettingsSection.Get<Api.Settings.JwtSettings>(); 
var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signingKey = new SymmetricSecurityKey(key);
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signingKey,
    };
});

builder.Services.AddControllers();

// Add custom services and repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("Infrastructure"))
);

builder.Services.AddAutoMapper(typeof(MappingProfiles));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
