using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class TokenProvider(
    IConfiguration configuration,
    IUserRoleRepository userRoleRepository,
    RoleManager<AppRole> roleManager
    ) : ITokenProvider
{
    public async Task<string> CreateTokenAsync(AppUser user)
    {
        List<AppUserRole> appUserRoles = await userRoleRepository.Where(r => r.UserId == user.Id).ToListAsync();
        List<AppRole> appRoles = new List<AppRole>();

        foreach (var userRole in appUserRoles)
        {
            AppRole? role = await roleManager.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefaultAsync();
            if (role is not null)
            {
                appRoles.Add(role);
            }
        }

        List<string?> stringRoles = appRoles.Select(r => r.Name).ToList();
        
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.FullName),
            new Claim(ClaimTypes.Email,user.Email ?? ""),
            new Claim("UserName",user.UserName ?? ""),
            new Claim(ClaimTypes.Role,JsonSerializer.Serialize(stringRoles))
        };

        DateTime expireDate = DateTime.Now.AddDays(30);

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value ?? string.Empty));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration.GetSection("Jwt:Issuer").Value,
            audience: configuration.GetSection("Jwt:Audience").Value,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expireDate,
            signingCredentials: credentials
        );
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        string token = tokenHandler.WriteToken(jwtSecurityToken);

        return token;
    }
}