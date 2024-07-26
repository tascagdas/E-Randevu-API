using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Doctors.GetAllDoctors;

internal class GetAllDoctorQueryHandler(IDoctorRepository doctorRepository): IRequestHandler<GetAllDoctorsQueryRequest, Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsQueryRequest request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors = await doctorRepository.GetAll()
            .OrderBy(d => d.Department)
            .ThenBy(d => d.FirstName)
            .ToListAsync(cancellationToken);
        return doctors;
    }
}