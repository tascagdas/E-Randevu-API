using MediatR;
using TS.Result;

namespace Application.Features.Users.GetAllUsersQuery;

public class GetAllUsersQueryRequest: IRequest<Result<List<GetAllUsersQueryResponse>>>;