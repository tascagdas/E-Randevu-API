using Domain.Entities;

namespace Application.Services;

public interface ITokenProvider
{
    Task<string> CreateTokenAsync(AppUser user);
}