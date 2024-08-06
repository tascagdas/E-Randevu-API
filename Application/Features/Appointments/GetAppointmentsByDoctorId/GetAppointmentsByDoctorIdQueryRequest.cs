using MediatR;
using TS.Result;

namespace Application.Features.Appointments.GetAppointmentsByDoctorId;

public class GetAppointmentsByDoctorIdQueryRequest : IRequest<Result<List<GetAppointmentsByDoctorIdQueryResponse>>>
{
    public Guid DoctorId { get; set; }
}