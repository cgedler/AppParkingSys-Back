using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Data.Repositories;

using Services.App;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
string? keytoken = config["Jwt:Key"]; // campo nulo
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
   
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keytoken));
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
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService)); 
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddAutoMapper(typeof(StartupBase));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
