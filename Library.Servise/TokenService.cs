using Library.Core.Models;
using Library.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Servise;
public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config) =>
        _config = config;
    public string CreateToken(string nickname)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, nickname),
        };

        SigningCredentials signingCredentials =
            new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
        var jwt = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: nickname,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(40)),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    private SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        string key = _config["Jwt:Key"];
        if (key.IsNullOrEmpty())
            throw new ApplicationException("Empty configuration for Jwt:Key");

        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}
