using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class TokenProvider : ITokenProvider
{
    public string CreateToken(AppUser user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.FullName),
            new Claim(ClaimTypes.Email,user.Email ?? ""),
            new Claim("UserName",user.UserName ?? ""),
        };

        DateTime expireDate = DateTime.Now.AddDays(30);

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gencay yildiz cok kral adam... buranin uzun bir deger olmasi gerekli bu sefer eminim."));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: "Çağdaş Taş",
            audience: "E-randevu",
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