using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Auth.Login;

internal class LoginCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<LoginCommand , Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        AppUser? user = await userManager.Users.FirstOrDefaultAsync(u=>
                u.UserName == request.UserNameOrEmail ||
                u.Email == request.UserNameOrEmail,
            cancellationToken);
        if (user == null)
        {
            return Result<LoginCommandResponse>.Failure("Kullanıcı bulunamadı.");
        }

        bool isPasswordTrue = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordTrue)
        {
            return Result<LoginCommandResponse>.Failure("Şifre Hatalı");
        }

        return Result<LoginCommandResponse>.Succeed(new LoginCommandResponse(""));
    }
}