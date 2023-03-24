using Library.Core;
using Library.Core.Models;
using Library.Core.Security;
using Library.Core.Services;
using Library.Core.UnitOfWork;
using Library.DAL;
using Library.DAL.UnitOfWork;
using Library.Servise;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
string? connection = config.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"])
            ),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IAuthenticationService, AuthenticateService>()
    .AddScoped<IBookService, BookService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IRegistrationService, RegistrationService>()
    .AddScoped<ITokenService, TokenService>()
    .AddSingleton<IHasher, Hasher>()
    .AddAutoMapper(typeof(LibraryProfile))
    .AddDbContext<LibraryDbContext>(option =>
        option.UseSqlServer(connection));




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
