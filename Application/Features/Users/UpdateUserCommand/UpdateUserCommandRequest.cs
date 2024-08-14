using MediatR;
using TS.Result;

namespace Application.Features.Users.UpdateUserCommand;

public class UpdateUserCommandRequest: IRequest<Result<string>>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }  
    public List<Guid>? RoleIds { get; set; }
}