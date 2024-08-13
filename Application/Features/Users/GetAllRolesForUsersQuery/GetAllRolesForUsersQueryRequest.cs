using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Users.GetAllRolesForUsersQuery;

public class GetAllRolesForUsersQueryRequest: IRequest<Result<List<AppRole>>>
{
    
}