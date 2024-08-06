using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Appointments.GetDoctorsByDepartmentQuery;

public class GetDoctorsByDepartmentQueryHandler(IDoctorRepository doctorRepository) :IRequestHandler<GetDoctorsByDepartmentQueryRequest,Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(GetDoctorsByDepartmentQueryRequest request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors =
            await doctorRepository
                .Where(d => d.Department == request.DepartmentValue)
            .OrderBy(d => d.LastName).ToListAsync(cancellationToken: cancellationToken);
        return doctors;
    }
}