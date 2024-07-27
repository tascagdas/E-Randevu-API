using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Doctors.CreateDoctor;

public class CreateDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ):IRequestHandler<CreateDoctorCommandRequest,Result<string>>
{
    public async Task<Result<string>> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        Doctor doctor = mapper.Map<Doctor>(request);
        await doctorRepository.AddAsync(doctor, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Doktor başarıyla eklenmiştir.";
    }
}