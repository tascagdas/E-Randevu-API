using MediatR;
using TS.Result;

namespace Application.Features.Appointments.DeleteAppointmentCommand;

public class DeleteAppointmentCommandRequest:IRequest<Result<string>>
{
    public Guid AppointmentId { get; set; }
}