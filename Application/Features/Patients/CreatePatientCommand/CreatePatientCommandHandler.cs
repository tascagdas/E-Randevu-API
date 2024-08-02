using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.CreatePatientCommand;

public class CreatePatientCommandHandler(IPatientRepository patientRepository,IUnitOfWork unitOfWork, IMapper mapper):IRequestHandler<CreatePatientCommandRequest,Result<HttpStatusCode>>
{
    public async Task<Result<HttpStatusCode>> Handle(CreatePatientCommandRequest request, CancellationToken cancellationToken)
    {
        if (patientRepository.Any(p=>p.IdentityNumber == request.IdentityNumber))
        {
            return new Result<HttpStatusCode>(400, "Girilen TC kimlik numarası ile bir kayıt bulunmakta.");
        }
        
        Patient patient = mapper.Map<Patient>(request);
        await patientRepository.AddAsync(patient, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Result<HttpStatusCode>(HttpStatusCode.Created);
    }
}