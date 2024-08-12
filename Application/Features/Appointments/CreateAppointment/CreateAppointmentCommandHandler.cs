using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace Application.Features.Appointments.CreateAppointment;

public class CreateAppointmentCommandHandler(
    IPatientRepository patientRepository,
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateAppointmentCommandRequest, Result<string>>
{
    public async Task<Result<string>> Handle(CreateAppointmentCommandRequest request,
        CancellationToken cancellationToken)
    {
        Patient? patient =
            await patientRepository.GetByExpressionAsync(p => p.IdentityNumber == request.IdentityNumber);
        if (patient is null)
        {
            return Result<string>.Failure(404, "Kullanıcı bulunamadı.");
        }

        if (request.IdentityNumber is null)
        {
            return Result<string>.Failure("Açıklama kısmına hastanın tc kimlik nosunu giriniz.");
        }

        DateTime startDate = Convert.ToDateTime(request.StartDate);
        DateTime endDate = Convert.ToDateTime(request.EndDate);

        bool isAppointmentTaken = await appointmentRepository
            .AnyAsync(a =>
                    a.DoctorId == request.DoctorId && (
                        (a.StarTime < endDate && a.StarTime >= startDate) ||
                        (a.EndTime > startDate && a.EndTime <= endDate) ||
                        (a.StarTime >= startDate && a.EndTime <= endDate) ||
                        (a.StarTime <= startDate && a.EndTime >= endDate)),
                cancellationToken);
        if (isAppointmentTaken)
        {
            return Result<string>.Failure("Bu randevu tarihi müsait değildir.");
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