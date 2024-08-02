using System.Net;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.CreatePatientCommand;

public class CreatePatientCommandRequest:IRequest<Result<HttpStatusCode>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public string City { get; set; }
    public string Town { get; set; }
    public string FullAddress { get; set; }
}