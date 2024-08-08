using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Appointments.CreateAppointment;

public class CreateAppointmentCommandHandler(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork):IRequestHandler<CreateAppointmentCommandRequest,Result<string>>
{
    public async Task<Result<string>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionAsync(p => p.IdentityNumber == request.IdentityNumber);
        if (patient is null)
        {
            return Result<string>.Failure(404, "Kullanıcı bulunamadı.");
        }

        Appointment appointment = new Appointment()
        {
            DoctorId = request.DoctorId,
            PatientId = patient.PatientId,
            StarTime = Convert.ToDateTime(request.StartDate),
            EndTime = Convert.ToDateTime(request.EndDate),
            IsCompleted = false
        };
        await appointmentRepository.AddAsync(appointment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Randevu başarıyla oluşturuldu.");
    }
}