using MediatR;
using TS.Result;

namespace Application.Features.Users.CreateUser;

public class CreateUserCommandRequest: IRequest<Result<string>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }  
    public string Password { get; set; }
    public List<Guid> RoleIds { get; set; }

}