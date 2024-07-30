using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Doctors.DeleteDoctorById;

public class DeleteDoctorByIdCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork):IRequestHandler<DeleteDoctorByIdCommandRequest,Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDoctorByIdCommandRequest request, CancellationToken cancellationToken)
    {
        Doctor? doctor = await doctorRepository.GetByExpressionAsync(d => d.DoctorId == request.Id, cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doktor bulunamadı.");
        }
        doctorRepository.Delete(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Doktor başarıyla silindi.");
    }
}