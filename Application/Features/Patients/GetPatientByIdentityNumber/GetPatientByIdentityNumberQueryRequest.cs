using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.GetPatientByIdentityNumber;

public class GetPatientByIdentityNumberQueryRequest:IRequest<Result<Patient>>
{
    public string IdentityNumber { get; set; }
}