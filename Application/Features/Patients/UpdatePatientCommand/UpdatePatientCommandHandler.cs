using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.UpdatePatientCommand;

public class UpdatePatientCommandHandler( IPatientRepository patientRepository, IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<UpdatePatientCommandRequest,Result<HttpStatusCode>>
{
    public async Task<Result<HttpStatusCode>> Handle(UpdatePatientCommandRequest request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionWithTrackingAsync(p => p.PatientId == request.PatientId, cancellationToken);

        if (patient is null)
        {
            return new Result<HttpStatusCode>(404,"Hasta bulunamadı.");
        }

        if(patient.IdentityNumber != request.IdentityNumber)
        {
            if(patientRepository.Any(p=> p.IdentityNumber == request.IdentityNumber))
            {
                return new Result<HttpStatusCode>(400, "Girilen TC kimlik numarası ile bir kayıt bulunmakta.");
            }
        }

        mapper.Map(request, patient);

        patientRepository.Update(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Result<HttpStatusCode>(HttpStatusCode.NoContent);
    }
}