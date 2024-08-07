using Domain.Entities;
using Domain.Repositories;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.GetPatientByIdentityNumber;

public class GetPatientByIdentityNumberQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetPatientByIdentityNumberQueryRequest,Result<Patient>>
{
    public async Task<Result<Patient>> Handle(GetPatientByIdentityNumberQueryRequest request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionAsync(p => p.IdentityNumber == request.IdentityNumber);
        return patient;
    }
}