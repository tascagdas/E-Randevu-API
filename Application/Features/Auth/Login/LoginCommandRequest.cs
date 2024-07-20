using MediatR;
using TS.Result;

namespace Application.Features.Auth.Login;

public record LoginCommandRequest(string UserNameOrEmail, string Password) : IRequest<Result<LoginCommandResponse>>;
//Burada abstract keywordu kullanmak soruna yol açıyordu. "Deserialization of reference types without parameterless constructor is not supported" hatası veriyordu.