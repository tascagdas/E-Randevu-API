using Domain.Entities;
using MediatR;
using TS.Result;

namespace Application.Features.Appointments.GetDoctorsByDepartmentQuery;

public class GetDoctorsByDepartmentQueryRequest:IRequest<Result<List<Doctor>>>
{
    public int DepartmentValue { get; set; }
}