using MediatR;
using TS.Result;

namespace Application.Features.Auth.Login;

public abstract record LoginCommand(string UserNameOrEmail, string Password) : IRequest<Result<LoginCommandResponse>>;