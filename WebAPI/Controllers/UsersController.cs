using Application.Features.Users.CreateUser;
using Application.Features.Users.DeleteUserByIdCommand;
using Application.Features.Users.GetAllRolesForUsersQuery;
using Application.Features.Users.GetAllUsersQuery;
using Application.Features.Users.UpdateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Abstractions;

namespace WebAPI.Controllers;

public class UsersController:ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
        
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAllRoles(GetAllRolesForUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteUserByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}