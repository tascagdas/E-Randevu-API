using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Users.GetAllRolesForUsersQuery;

public class GetAllRolesForUsersQueryHandler(
    RoleManager<AppRole> roleManager) : IRequestHandler<GetAllRolesForUsersQueryRequest, Result<List<AppRole>>>
{
    public async Task<Result<List<AppRole>>> Handle(GetAllRolesForUsersQueryRequest request, CancellationToken cancellationToken)
    {
        List<AppRole> roles = await roleManager.Roles.OrderBy(p=> p.Name).ToListAsync(cancellationToken);

        return roles;
    }
}