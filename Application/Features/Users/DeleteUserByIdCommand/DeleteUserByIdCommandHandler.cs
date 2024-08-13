using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace Application.Features.Users.DeleteUserByIdCommand;

public class DeleteUserByIdCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<DeleteUserByIdCommandRequest, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserByIdCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByIdAsync(request.Id.ToString());
        if (appUser is null)
        {
            return Result<string>.Failure("Kullanıcı bulunamadı");
        }

        IdentityResult result = await userManager.DeleteAsync(appUser);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }

        return "Kullanıcı başarıyla silindi.";
    }
}