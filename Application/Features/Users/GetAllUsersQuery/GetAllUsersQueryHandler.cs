using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Users.GetAllUsersQuery;

public class GetAllUsersQueryHandler(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    IUserRoleRepository userRoleRepository
) : IRequestHandler<GetAllUsersQueryRequest, Result<List<GetAllUsersQueryResponse>>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        List<AppUser> users = await userManager.Users.OrderBy(p=> p.FirstName).ToListAsync(cancellationToken);

        List<GetAllUsersQueryResponse> response =
            users.Select(s => new GetAllUsersQueryResponse()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                FullName = s.FullName,
                UserName = s.UserName,
                Email = s.Email
            }).ToList();

        foreach (var item in response)
        {
            List<AppUserRole> userRoles = await userRoleRepository.Where(p => p.UserId == item.Id).ToListAsync(cancellationToken);

            List<Guid> stringRoles = new();
            List<string?> stringRoleNames = new();

            foreach (var userRole in userRoles)
            {
                AppRole? role = 
                    await roleManager
                        .Roles
                        .Where(p=> p.Id == userRole.RoleId)
                        .FirstOrDefaultAsync(cancellationToken);

                if(role is not null)
                {
                    stringRoles.Add(role.Id);
                    stringRoleNames.Add(role.Name);
                }
            }           

            item.RoleIds = stringRoles;
            item.RoleNames = stringRoleNames;
        }

        return response;
    }
}