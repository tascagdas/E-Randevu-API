using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Users.CreateUser;

public class CreateUserCommandHandler(
    UserManager<AppUser> userManager,
    IUserRoleRepository userRoleRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ): IRequestHandler<CreateUserCommandRequest, Result<string>>
{
    public async Task<Result<string>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        if(await userManager.Users.AnyAsync(p=> p.Email == request.Email, cancellationToken: cancellationToken))
        {
            return Result<string>.Failure("Email zaten kullanılmakta.");
        }

        if (await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken: cancellationToken))
        {
            return Result<string>.Failure("Kullanıcı adı zaten kullanılmakta.");
        }

        AppUser user = mapper.Map<AppUser>(request);
        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if(!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }


        if (request.RoleIds.Any())
        {
            List<AppUserRole> userRoles = new();
            foreach (var roleId in request.RoleIds)
            {
                AppUserRole userRole = new()
                {
                    RoleId = roleId,
                    UserId = user.Id
                };
                userRoles.Add(userRole);
            }

            await userRoleRepository.AddRangeAsync(userRoles, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return "Kullanıcı oluşturma başarılı";
    }
}