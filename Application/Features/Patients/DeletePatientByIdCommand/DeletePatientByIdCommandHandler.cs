using System.Net;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Patients.DeletePatientByIdCommand;

public class DeletePatientByIdCommandHandler (IPatientRepository patientRepository, IUnitOfWork unitOfWork) :IRequestHandler<DeletePatientByIdCommandRequest,Result<HttpStatusCode>>
{
    public async Task<Result<HttpStatusCode>> Handle(DeletePatientByIdCommandRequest request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionAsync(p => p.PatientId == request.Id, cancellationToken);

        if(patient is null)
        {
            return Result<HttpStatusCode>.Failure(404, "Hasta Bulunamadı");
        }

        patientRepository.Delete(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Result<HttpStatusCode>(200, "Hasta başarıyla silindi.");
    }
}