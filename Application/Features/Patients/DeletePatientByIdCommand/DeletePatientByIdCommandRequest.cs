using System.Net;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.DeletePatientByIdCommand;

public class DeletePatientByIdCommandRequest : IRequest<Result<HttpStatusCode>>
{
    public Guid Id { get; set; }
}