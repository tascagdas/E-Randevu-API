using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class UserRoleRepository: Repository <UserRoleRepository , ApplicationDbContext>
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}