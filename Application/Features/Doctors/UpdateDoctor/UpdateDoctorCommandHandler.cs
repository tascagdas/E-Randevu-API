using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Doctors.UpdateDoctor;

public class UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateDoctorCommandRequest, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        Doctor? doctor =
            await doctorRepository.GetByExpressionWithTrackingAsync(d => d.DoctorId == request.DoctorId, cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doktor bulunamadı.");
        }

        mapper.Map(request, doctor);
        
        doctorRepository.Update(doctor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Doktor başarılı bir şekilde güncellendi.";
    }
}