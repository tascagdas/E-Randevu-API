using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Roles.RoleSync;

public class RoleSyncCommandHandler (RoleManager<AppRole> roleManager): IRequestHandler<RoleSyncCommand,Result<string>>
{
    public async Task<Result<string>> Handle(RoleSyncCommand request, CancellationToken cancellationToken)
    {
        List<AppRole> currentRoles = await roleManager.Roles.ToListAsync(cancellationToken);
        List<AppRole> staticRoles = Constants.GetRoles();
        foreach (var role in currentRoles)
        {
            if (!staticRoles.Any(r=>r.Name==role.Name))
            {
                await roleManager.DeleteAsync(role);
            }
        }
        foreach (var role in staticRoles)
        {
            if (!currentRoles.Any(r=>r.Name==role.Name))
            {
                await roleManager.CreateAsync(role);
            }   
        }

        return "Role senkronizasyonu basarili";
    }
}