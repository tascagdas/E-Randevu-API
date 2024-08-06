using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace Application.Features.Appointments.GetAppointmentsByDoctorId;

public class GetAppointmentsByDoctorIdQueryHandler(IAppointmentRepository appointmentRepository)
    : IRequestHandler<GetAppointmentsByDoctorIdQueryRequest, Result<List<GetAppointmentsByDoctorIdQueryResponse>>>
{
    public async Task<Result<List<GetAppointmentsByDoctorIdQueryResponse>>> Handle(
        GetAppointmentsByDoctorIdQueryRequest request, CancellationToken cancellationToken)
    {
        List<Appointment> appointments =
            await appointmentRepository
                .Where(a => a.DoctorId == request.DoctorId)
                .Include(a => a.Patient)
                .ToListAsync(cancellationToken: cancellationToken);

        List<GetAppointmentsByDoctorIdQueryResponse> queryResponse =
            appointments.Select(a => new GetAppointmentsByDoctorIdQueryResponse(
                    a.AppointmentId,
                    a.EndTime,
                    a.StarTime,
                    a.Patient!.FullName,
                    a.Patient))
                .ToList();

        return queryResponse;
    }
}