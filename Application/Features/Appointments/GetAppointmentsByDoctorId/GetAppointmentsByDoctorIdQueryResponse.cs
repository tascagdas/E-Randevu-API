using Domain.Entities;

namespace Application.Features.Appointments.GetAppointmentsByDoctorId;

public record GetAppointmentsByDoctorIdQueryResponse
(
     Guid Id,
     DateTime StartDate,
     DateTime EndDate,
     string Title,
     Patient Patient
);