using System.Net;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.UpdatePatientCommand;

public class UpdatePatientCommandRequest :IRequest<Result<HttpStatusCode>>
{
    public Guid PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public string City { get; set; }
    public string Town { get; set; }
    public string FullAddress { get; set; }
}