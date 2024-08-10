using MediatR;
using TS.Result;

namespace Application.Features.Appointments.UpdateAppointmentCommand;

public class UpdateAppointmentCommandRequest:IRequest<Result<string>>
{
    public Guid AppointmentId { get; set; }
    public string startDate { get; set; }
    public string endDate { get; set; }
}