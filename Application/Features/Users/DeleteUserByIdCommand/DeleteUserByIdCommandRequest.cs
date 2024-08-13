using MediatR;
using TS.Result;

namespace Application.Features.Users.DeleteUserByIdCommand;

public class DeleteUserByIdCommandRequest: IRequest<Result<string>>
{
    public Guid Id { get; set; }
}