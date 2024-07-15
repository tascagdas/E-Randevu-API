using Domain.Entities;

namespace Application.Services;

public interface ITokenProvider
{
    string CreateToken(AppUser user);
}