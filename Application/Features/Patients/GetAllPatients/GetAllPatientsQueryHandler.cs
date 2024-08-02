using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Patients.GetAllPatients;

public class GetAllPatientsQueryHandler (IPatientRepository patientRepository):IRequestHandler<GetAllPatientsQueryRequest,Result<List<Patient>>>
{
    public async Task<Result<List<Patient>>> Handle(GetAllPatientsQueryRequest request, CancellationToken cancellationToken)
    {
        List<Patient> patients = await patientRepository.GetAll().OrderBy(p => p.FirstName).ToListAsync(cancellationToken: cancellationToken);

        return patients;
    }
}