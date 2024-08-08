using MediatR;
using TS.Result;

namespace Application.Features.Appointments.CreateAppointment;

public class CreateAppointmentCommandRequest :IRequest<Result<string>>
{
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public Guid DoctorId { get; set; }
    public string IdentityNumber { get; set; }
}